using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlLinkage.Manager;
using UserControlLinkage.Models;

namespace UserControlLinkage.ViewModels
{
    public class MenuViewModel : IDisposable
    {
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();

        private MenuModel menu1 = new MenuModel(1);
        private MenuModel menu2 = new MenuModel(2);
        private MenuModel menu3 = new MenuModel(-1);    // 動作しない
        public ReactiveProperty<int> Menu1 { get; private set; }
        public ReactiveProperty<int> Menu2 { get; private set; }
        public ReactiveProperty<int> Menu3 { get; private set; }

        public ReactiveCommand Menu1Command { get; private set; }
        public ReactiveCommand Menu2Command { get; private set; }
        public ReactiveCommand Menu3Command { get; private set; }

        public MenuViewModel()
        {
            var menu1p = this.menu1
            // IO<T>に変換するプロパティを指定
            .ObserveProperty(o => o.No)
            // IO<T>になったのでReactivePropertyに変換可能
            .ToReactiveProperty();

            var menu2p = this.menu2
            // IO<T>に変換するプロパティを指定
            .ObserveProperty(o => o.No)
            // IO<T>になったのでReactivePropertyに変換可能
            .ToReactiveProperty();

            var menu3p = this.menu3
            // IO<T>に変換するプロパティを指定
            .ObserveProperty(o => o.No)
            // IO<T>になったのでReactivePropertyに変換可能
            .ToReactiveProperty();

            this.Menu1Command = menu1p
                // IO<bool>へ変換
                .Select(o => o > 0)
                // コマンドへ変換
                .ToReactiveCommand()
                .AddTo(this.Disposable);
            this.Menu1Command
                .Subscribe(_ => this.menu1.MenuClick());

            this.Menu2Command = menu2p
                // IO<bool>へ変換
                .Select(o => o > 0)
                // コマンドへ変換
                .ToReactiveCommand()
                .AddTo(this.Disposable);
            this.Menu2Command
                .Subscribe(_ => this.menu2.MenuClick());

            this.Menu3Command = menu3p
                // IO<bool>へ変換
                .Select(o => o > 0)
                // コマンドへ変換
                .ToReactiveCommand()
                .AddTo(this.Disposable);
            this.Menu3Command
                .Subscribe(_ => this.menu3.MenuClick());
        }

        public void Dispose()
        {
            // まとめてDisposeする
            Disposable.Dispose();
        }
    }
}
