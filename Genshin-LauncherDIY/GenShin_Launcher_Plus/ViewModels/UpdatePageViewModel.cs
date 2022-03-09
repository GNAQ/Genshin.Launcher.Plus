﻿using GenShin_Launcher_Plus.Core;
using MahApps.Metro.Controls.Dialogs;
using System;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using GenShin_Launcher_Plus.Models;

namespace GenShin_Launcher_Plus.ViewModels
{
    public class UpdatePageViewModel : ObservableObject
    {
        private IDialogCoordinator dialogCoordinator;
        public UpdatePageViewModel(IDialogCoordinator instance)
        {
            languages = MainBase.lang;
            dialogCoordinator = instance;
            UpdateRunCommand = new RelayCommand(UpdateRun);
        }
        public LanguagesModel languages { get; set; }
        public string Notify
        {
            get => MainBase.update.Content;
        }
        public string Title
        {
            get => MainBase.update.Title;
        }

        private bool _ButtonIsEnabled = true;
        public bool ButtonIsEnabled
        {
            get => _ButtonIsEnabled;
            set => SetProperty(ref _ButtonIsEnabled, value);
        }

        private double _DownloadBarMax;
        public double DownloadBarMax
        {
            get => _DownloadBarMax;
            set => SetProperty(ref _DownloadBarMax, value);
        }

        private double _DownloadBarValue;
        public double DownloadBarValue
        {
            get => _DownloadBarValue;
            set => SetProperty(ref _DownloadBarValue, value);
        }

        private string _DownloadLabel;
        public string DownloadLabel
        {
            get => _DownloadLabel;
            set => SetProperty(ref _DownloadLabel, value);
        }


        public ICommand UpdateRunCommand { get; set; }
        private async void UpdateRun()
        {
            if (ButtonIsEnabled)
            {
                ButtonIsEnabled = false;
                string updatefile = MainBase.update.DownloadUrl;
                if (await HttpFileExistAsync(updatefile) == true)
                {
                    await DownloadHttpFileAsync(updatefile, @"UpdateTemp.upd");
                }
                else
                {
                    await dialogCoordinator.ShowMessageAsync(this, languages.Error, languages.DownFailedStr, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = languages.Determine });
                    ButtonIsEnabled = true;
                }
            }
            else
            {
                await dialogCoordinator.ShowMessageAsync(this, languages.TipsStr, languages.RepWarnStr, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = languages.Determine });
            }
        }

        private Lazy<HttpClient> LazyClient { get; } = new Lazy<HttpClient>(() => new HttpClient() { Timeout = Timeout.InfiniteTimeSpan });

        public async Task DownloadHttpFileAsync(string url, string fileName)
        {
            HttpResponseMessage response = await LazyClient.Value.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            if (!response.IsSuccessStatusCode)
            {
                return;
            }
            DownloadBarMax = (double)response.Content.Headers.ContentLength;

            using (Stream responseStream = await response.Content.ReadAsStreamAsync())
            {
                int bufferSize = 1024;
                using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize, true))
                {
                    byte[] buffer = new byte[bufferSize];
                    long progressBarValue = 0;
                    int bytesRead = 0;
                    do
                    {
                        bytesRead = await responseStream.ReadAsync(buffer, 0, buffer.Length);
                        await fileStream.WriteAsync(buffer, 0, bytesRead);
                        progressBarValue += bytesRead;
                        //fire and forget
                        SetProgressBar(progressBarValue);
                    }
                    while (bytesRead > 0);
                }
            }
            if ((await dialogCoordinator.ShowMessageAsync(this, languages.TipsStr, languages.DownloadComStr, MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings() { AffirmativeButtonText = languages.Cancel, NegativeButtonText = languages.Determine })) != MessageDialogResult.Affirmative)
            {
                Process.Start(@"Update.exe");
                Environment.Exit(0);
            }
            else
            {
                ButtonIsEnabled = true;
            }
        }
        private async Task<bool> HttpFileExistAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await LazyClient.Value.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                return response.IsSuccessStatusCode;
            }
            catch { }
            return false;
        }
        public delegate void ProgressBarSetter(double value);
        public void SetProgressBar(double value)
        {
            DownloadBarValue = value;
            DownloadLabel = $"{languages.DownProgress}:{value / DownloadBarMax:p2}";
        }
    }
}
