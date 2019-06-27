﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using AppleWirelessKeyboardCore.Views;
using AppleWirelessKeyboardCore;
using AppleWirelessKeyboardCore.Services;

namespace AppleWirelessKeyboardCore
{
	public static class TrayIcon
	{
		static TrayIcon()
		{
		}

		public static void Show()
		{
			CreateIcon();
		}

        public static void Close()
        {
            _Icon.Visible = false;
            _Icon.Dispose();
            _Icon = null;
        }

		private static NotifyIcon _Icon = new NotifyIcon();

		private static void CreateIcon()
		{
			_Icon.Text = "AppleWirelessKeyboard";
			_Icon.Icon = new Icon(App.GetResourceStream(new Uri("pack://application:,,,/Gnome-Preferences-Desktop-Keyboard-Shortcuts.ico")).Stream);
			_Icon.Visible = true;

			MenuItem[] menuItems = new[] { 
				new MenuItem(TranslationService.Current.Configure, TriggerConfigure),
				new MenuItem(TranslationService.Current.Restart, TriggerRestart),
				new MenuItem(TranslationService.Current.RefreshConnection, TriggerRefresh),
				new MenuItem(TranslationService.Current.Exit, TriggerExit)
			};

			ContextMenu menu = new ContextMenu(menuItems);
			_Icon.ContextMenu = menu;
		}

		private static void TriggerRestart(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(System.Windows.Application.ResourceAssembly.Location);
			System.Windows.Application.Current.Shutdown();
		}
		private static void TriggerConfigure(object sender, EventArgs e)
		{
			(new Configuration()).Show();
		}
		private static void TriggerExit(object sender, EventArgs e)
		{
			App.Current.Shutdown();
		}

		public static void TriggerRefresh(object sender, EventArgs e)
		{
            
		}
	}
}