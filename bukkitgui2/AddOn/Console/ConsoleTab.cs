﻿// ConsoleTab.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Controls;
using Net.Bertware.Bukkitgui2.Core.Configuration;
using Net.Bertware.Bukkitgui2.Core.Logging;
using Net.Bertware.Bukkitgui2.MinecraftInterop.OutputHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.PlayerHandler;
using Net.Bertware.Bukkitgui2.MinecraftInterop.ProcessHandler;
using Net.Bertware.Bukkitgui2.Properties;

namespace Net.Bertware.Bukkitgui2.AddOn.Console
{
	public partial class ConsoleTab : MetroUserControl, IAddonTab
	{
		public IAddon ParentAddon { get; set; }
		public static ConsoleTab Reference;

		public ConsoleTab()
		{
			Reference = this;
			InitializeComponent();

			MinecraftOutputHandler.OutputParsed += PrintOutput;
			ProcessHandler.ServerStarting += HandleServerStart;
			ProcessHandler.ServerStopped += HandleServerStop;
			CIConsoleInput.CommandSent += HandleCommandSent;
			PlayerHandler.PlayerListAddition += HandlePlayerAddition;
			PlayerHandler.PlayerListDeletion += HandlePlayerDeletion;

			MCCOut.MessageColorInfo = Color.FromArgb(Config.ReadInt("console", "color_info", Color.Blue.ToArgb()));
			MCCOut.MessageColorPlayerAction =
				Color.FromArgb(Config.ReadInt("console", "color_playeraction", Color.DarkGreen.ToArgb()));
			MCCOut.MessageColorSevere = Color.FromArgb(Config.ReadInt("console", "color_severe", Color.DarkRed.ToArgb()));
			MCCOut.MessageColorWarning =
				Color.FromArgb(Config.ReadInt("console", "color_warning", Color.DarkOrange.ToArgb()));
            MCCOut.UpdateColorCache();

            MCCOut.ShowDate = Config.ReadBool("console", "date", false);
			MCCOut.ShowTime = Config.ReadBool("console", "time", true);

			imgListPlayerFaces.Images.Clear();
			imgListPlayerFaces.Images.Add("default", Resources.player_face);

			MCCOut.Autoscroll = Config.ReadBool("console", "autoscroll", true);

			CIConsoleInput.AddAutocompleteSource(PlayerHandler.GetOnlinePlayerNames);
			CIConsoleInput.AddAutocompleteSource(GetKnownCommands);
		}


		/// <summary>
		///     Known commands for auto completion
		/// </summary>
		private static string[] GetKnownCommands()
		{
			return new[]{
				"version",
				"plugins",
				"reload",
				"timings",
				"tell <player> <message>",
				"kill",
				"me",
				"help",
				"say",
				"ban",
				"banlist",
				"pardon",
				"pardon-ip",
				"ban-ip",
				"op",
				"de-op",
				"kick",
				"tp",
				"give",
				"stop",
				"save-all",
				"save-on",
				"save-off",
				"list",
				"whitelist",
				"whitelist list",
				"whitelist reload",
				"time",
				"gamemode",
				"xp",
				"toggledownfall",
				"defaultgamemode",
				"enchant",
				"seed",
				"weather",
				"clear",
				"difficulty",
				"spawnpoint",
				"gamerule",
				"effect",
				"setidletimeout",
				"setworldspawn",
				"achievement give"
			};
		}


		/// <summary>
		///     Add a player to the listview
		/// </summary>
		/// <param name="player"></param>
		private void HandlePlayerAddition(Player player)
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (() => HandlePlayerAddition(player)));
			}
			else
			{
				player.DetailsLoaded += player_DetailsLoaded;
				ListViewItem lvi = new ListViewItem(player.DisplayName) {Tag = player, ImageKey = "default"};

				SlvPlayers.Items.Add(lvi);
			}
		}

		/// <summary>
		///     Remove a player from the listview
		/// </summary>
		/// <param name="player"></param>
		private void HandlePlayerDeletion(Player player)
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (() => HandlePlayerDeletion(player)));
			}
			else
			{
				ListViewItem lvi = FindPlayerListViewItem(player);

				if (lvi != null) SlvPlayers.Items.Remove(lvi);
				if (imgListPlayerFaces.Images.ContainsKey(player.Name))
					imgListPlayerFaces.Images.RemoveByKey(player.Name);
			}
		}


		private void player_DetailsLoaded(object sender, EventArgs e)
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) (() => player_DetailsLoaded(sender, e)));
			}
			else
			{
				Player p = (Player) sender;
				imgListPlayerFaces.Images.Add(p.Name, p.Minotar);
				ListViewItem lvi = FindPlayerListViewItem(p);
				if (lvi != null) lvi.ImageKey = p.Name;
			}
		}

		private ListViewItem FindPlayerListViewItem(Player player)
		{
			foreach (ListViewItem item in SlvPlayers.Items)
			{
				if (item.Tag == player) return item;
			}
			return null;
		}

		/// <summary>
		///     Handle starting server, prepare UI and display text
		/// </summary>
		private void HandleServerStart()
		{
			// clearing console is already performed by the starter routine, so the starter routine can display its own information too.
			SlvPlayers.Items.Clear();

			WriteOut("Starting server...");
		}

		/// <summary>
		///     Handle stopped server, clear UI.
		/// </summary>
		private void HandleServerStop()
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker) HandleServerStop);
			}
			else
			{
				SlvPlayers.Items.Clear();

				WriteOut("The server has stopped");
			}
		}

		/// <summary>
		///     Handle a commandsent event from the textbox and redirect it to the server
		/// </summary>
		/// <param name="text"></param>
		private static void HandleCommandSent(string text)
		{
			if (ProcessHandler.IsRunning)
			{
				ProcessHandler.SendInput(text);
			}
		}

		/// <summary>
		///     Write output to the console. Will be prefixed with [GUI]
		/// </summary>
		/// <param name="text"></param>
		public static void WriteOut(string text)
		{
			Reference.MCCOut.WriteOutput(MessageType.Info, "[GUI] " + text);
		}

		/// <summary>
		///     Print output to the console
		/// </summary>
		/// <param name="text"></param>
		/// <param name="outputParseResult"></param>
		private void PrintOutput(string text, OutputParseResult outputParseResult)
		{
			MCCOut.WriteOutput(outputParseResult.Type, outputParseResult.Message);
		}

		private void ContextPlayersKick_Click(object sender, EventArgs e)
		{
			if (SlvPlayers.SelectedItems.Count < 1) return;
			((Player) (SlvPlayers.SelectedItems[0].Tag)).Kick();
		}

		private void ContextPlayersBan_Click(object sender, EventArgs e)
		{
			if (SlvPlayers.SelectedItems.Count < 1) return;
			((Player) (SlvPlayers.SelectedItems[0].Tag)).Ban();
		}

		private void ContextPlayersBanIp_Click(object sender, EventArgs e)
		{
			if (SlvPlayers.SelectedItems.Count < 1) return;
			((Player) (SlvPlayers.SelectedItems[0].Tag)).BanIp();
		}

		private void ContextPlayersOp_Click(object sender, EventArgs e)
		{
			if (SlvPlayers.SelectedItems.Count < 1) return;
			((Player) (SlvPlayers.SelectedItems[0].Tag)).SetOp(true);
		}

		private void ContextPlayersDeOp_Click(object sender, EventArgs e)
		{
			if (SlvPlayers.SelectedItems.Count < 1) return;
			((Player) (SlvPlayers.SelectedItems[0].Tag)).SetOp(false);
		}

		private void ConsoleTab_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyData == Keys.F11)
					new EmulatorInput().Show();
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
			catch (Exception exception)
			{
				Logger.Log(LogLevel.Warning, "ConsoleTab", "Exception thrown while showing emulator", exception.Message);
			}
		}

		private void ContextPlayers_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			ContextPlayers.Enabled = (SlvPlayers.SelectedItems.Count > 0);
		}
	}
}