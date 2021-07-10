﻿using Eto;
using Eto.Drawing;
using Eto.Forms;
using Kuriimu2.EtoForms.Resources;
using System.Collections.Generic;

namespace Kuriimu2.EtoForms.Support
{
    //Will apply to all




    public class Themer
    {
        private static Dictionary<string, Theme> themeDict = new Dictionary<string, Theme>();

        public static void LoadThemes()
        {
            try
            {
                Themer.themeDict.Add("light", new Theme(KnownColors.ThemeLight, KnownColors.Black, KnownColors.Black, KnownColors.NeonGreen, KnownColors.DarkRed,
KnownColors.NeonGreen, KnownColors.Red, KnownColors.Orange, KnownColors.Wheat, Color.FromArgb(0xf0, 0xfd, 0xff), Color.FromArgb(0xcd, 0xf7, 0xfd),KnownColors.ControlLight
));
                Themer.themeDict.Add("dark", new Theme(KnownColors.ThemeDark, KnownColors.White, KnownColors.Wheat, KnownColors.NeonGreen, KnownColors.DarkRed,
                KnownColors.NeonGreen, KnownColors.Red, KnownColors.Orange, KnownColors.Wheat, KnownColors.DarkRed, KnownColors.DarkRed, KnownColors.ControlLight
                )) ;



            }catch(System.ArgumentException e)
            {

            }


            //Add try and catch later

            var theme = GetTheme();

            #region Styling

                #region cross platform
                Eto.Style.Add<Panel>(null, panel =>
            {
                panel.BackgroundColor = theme.mainColor;
            });

                Eto.Style.Add<Label>(null, text =>
                {
                    text.TextColor = theme.altColor;
                });
                Eto.Style.Add<Button>(null, button =>
                {
                    button.BackgroundColor = theme.mainColor;
                    button.TextColor = theme.altColor;
                });
                Eto.Style.Add<GridView>(null, gridview =>
                {
                    gridview.BackgroundColor = theme.mainColor;

                });
                Eto.Style.Add<Dialog>(null, dialog =>
                {
                    dialog.BackgroundColor = theme.mainColor;
                });
                Eto.Style.Add<CheckBox>(null, checkbox =>
                {
                    checkbox.BackgroundColor = theme.mainColor;
                    checkbox.TextColor = theme.altColor;
                });


                Eto.Style.Add<GroupBox>(null, groupBox =>
                {
                    groupBox.BackgroundColor = theme.mainColor;
                    groupBox.TextColor = theme.altColor;
                });





            /*
            Eto.Style.Add<TabControl>(null, tabPage =>
                {
                   tabPage.BackgroundColor = theme.mainColor;
                tabPage.
                //Padding = 0;
                //tabPage.TextColor = Support.KnownColors.White;
            });
            */
                #endregion
                //WPF
                #region WPF
                //Cast like this beacuse WPF can't use eto colors
                //Alpha has to be 255 otherwise MenuBar doesen't work

            }
            #endregion
            #endregion
        


        public static void ChangeTheme(string theme)
        {
            if (Application.Instance.Platform.IsWpf) {

                Settings.Default.Theme = theme;
                Settings.Default.Save();

                MessageBox.Show("Please restart to apply the theme.", "Restart");


            }
            else
            {
                MessageBox.Show("Sorry, themes are not supported on your platform.", "Unsupported Platform Error");
            }

        }
        public static Theme GetTheme()
        {
            try
            {
                return themeDict[Settings.Default.Theme];
            }
            catch (KeyNotFoundException e)
            {
                return themeDict["light"];
            }
            
        }


    }


}

public class Theme
{
    public Color mainColor { get; private set; }
    public Color altColor { get; private set; }
    public Color loggerBackColor { get; private set; }
    public Color loggerTextColor { get; private set; }
    public Color failColor { get; private set; }
    public Color logInfoColor { get; private set; }
    public Color logErrorColor { get; private set; }
    public Color logWarningColor { get; private set; }
    public Color logDefaultColor { get; private set; }
    public Color hexByteBack1Color { get; private set; }
    public Color hexSidebarBackColor { get; private set; }
    public Color controlColor { get; private set; }
    public Theme(Color mainColor, Color altColor, Color loggerBackColor, Color loggerTextColor,
        Color failColor,Color logInfoColor,Color logErrorColor,Color logWarningColor,Color logDefaultColor,
        Color hexByteBack1Color,Color hexSidebarBackColor,Color controlColor)
    {
        this.mainColor = mainColor;
        this.altColor = altColor;
        this.loggerBackColor = loggerBackColor;
        this.failColor = failColor;
        this.logInfoColor = logInfoColor;
        this.logErrorColor = logErrorColor;
        this.logWarningColor = logWarningColor;
        this.logDefaultColor = logDefaultColor;
        this.hexByteBack1Color = hexByteBack1Color;
        this.hexSidebarBackColor = hexSidebarBackColor;
        this.controlColor = controlColor;
    }



}