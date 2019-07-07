using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using UserControlLinkage.Models;
using UserControlLinkage.ViewModels;

namespace UserControlLinkage.Manager
{
    public class GlobalMonitoringManager : IDisposable
    {
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();

        public ReactiveProperty<MainContents> MainContents { get; private set; } = new ReactiveProperty<MainContents>(new MainContents1());
        public ReactiveProperty<string> Title { get; private set; } = new ReactiveProperty<string>("コンテンツ１");

        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        public static readonly GlobalMonitoringManager Instance = new GlobalMonitoringManager();

        /// <summary>
        /// シングルトン化コード
        /// </summary>
        static GlobalMonitoringManager()
        {
        }

        /// <summary>
        /// シングルトン化コード
        /// </summary>
        private GlobalMonitoringManager()
        {
            this.MainContents.ToReactiveProperty().AddTo(this.Disposable);
            this.Title.AddTo(this.Disposable);
        }

        public void Dispose()
        {
            // まとめてDisposeする
            Disposable.Dispose();
        }
    }
}
