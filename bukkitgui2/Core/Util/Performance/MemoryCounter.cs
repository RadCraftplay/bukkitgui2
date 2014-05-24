﻿// MemoryCounter.cs in bukkitgui2/bukkitgui2
// Created 2014/05/24
// Last edited at 2014/05/24 12:16
// ©Bertware, visit http://bertware.net

using System;
using System.Diagnostics;
using System.Timers;
using Microsoft.VisualBasic.Devices;

namespace Net.Bertware.Bukkitgui2.Core.Util.Performance
{
	/// <summary>
	///     Provide information over total, used, available memory
	/// </summary>
	internal class MemoryCounter
	{
		private const int Interval = 500;
		private readonly int _pid;
		private Int32 _value;
		private readonly Int32 _totalMemoryMb = TotalMemoryMb();
		private Timer _updateTimer;

		public MemoryCounter()
		{
			Initialize();
		}

		public MemoryCounter(int pid)
		{
			_pid = pid;
			Initialize();
		}

		private void Initialize()
		{
			_updateTimer = new Timer(Interval);
			_updateTimer.AutoReset = true;
			_updateTimer.Elapsed += OnTimerElapsed;
			_updateTimer.Start();
		}

		private void OnTimerElapsed(object sender, ElapsedEventArgs e)
		{
			UpdateStats();
		}

		public void UpdateStats()
		{
			if (_pid == 0)
			{
				_value = _totalMemoryMb - ToMb(new Computer().Info.AvailablePhysicalMemory);
			}
			else
			{
				// _value = ToMb(Wmi.GetprocessInfo(Wmi.ProcessProp.WorkingSetSize, _pid));
				_value = ToMb(Process.GetProcessById(_pid).WorkingSet64);
			}
		}

		public Int64 MemoryUsageMb
		{
			get { return _value; }
		}

		public int MemoryUsagePct
		{
			get { return (100*_value/_totalMemoryMb); }
		}

		public void Enable()
		{
			if (_updateTimer != null) _updateTimer.Enabled = true;
		}

		public void Disable()
		{
			if (_updateTimer != null) _updateTimer.Enabled = false;
		}

		public static Int64 TotalMemory()
		{
			return Convert.ToInt64(new Computer().Info.TotalPhysicalMemory);
		}

		public static Int32 TotalMemoryMb()
		{
			return Convert.ToInt32(TotalMemory()/1048576);
		}

		public static Int32 ToMb(string bytesStr)
		{
			Int64 bytes;
			Int64.TryParse(bytesStr, out bytes);
			return ToMb(bytes);
		}

		public static Int32 ToMb(Int64 bytes)
		{
			return Convert.ToInt32(bytes/1048576);
		}

		public static Int32 ToMb(UInt64 bytes)
		{
			return Convert.ToInt32(bytes/1048576);
		}
	}
}