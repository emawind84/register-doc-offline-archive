﻿using pmis.i18n;
using System;
using System.Windows;

namespace pmis
{
    /// <summary>
    /// Interaction logic for TokenRequest.xaml
    /// </summary>
    public partial class TokenRequestWindow : Window
    {

        private string host;

        public event EventHandler<string> AfterRequestComplete;

        public TokenRequestWindow(string host)
        {
            try
            {
                InitializeComponent();
                this.Owner = App.Current.MainWindow;
                this.host = host;
                this.pmisUsername.Focus();
                LoadLanguage();
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
        }

        private async void RequestPMISToken(object sender, RoutedEventArgs e)
        {
            try
            {
                this.requestTokenButton.IsEnabled = false;
                bool pwdEncoded = passwordBase64Encoded.IsChecked.Value;
                var obj = await AppUtil.RequestPMISToken(host, pmisUsername.Text, pmisPassword.Password, pwdEncoded);
                AfterRequestComplete?.Invoke(this, obj["access_token"] as string);
            }
            catch (Exception ex)
            {
                ex.Log().Display();
            }
            finally
            {
                this.requestTokenButton.IsEnabled = true;
            }
        }

        private void LoadLanguage(object sender = null, EventArgs args = null)
        {
            LanguageSupport i18n = new LanguageSupport();
            i18n.SetTokenRequestFormLanguage(this);
        }
    }
}
