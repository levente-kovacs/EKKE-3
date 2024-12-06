using Kliens.Core;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Kliens
{
    public class BasePage : Page
    {
        public BasePage()
        {
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

             Loaded += BasePage_Loaded;
            
        }

        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            if (ShouldAnimateOut)
                await AnimateOut();
            else
                await AnimateIn();
        }

        public async Task AnimateIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(this.SlideSeconds);

                    break;
            }
        }

        public async Task AnimateOut()
        {
            if (this.PageUnLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnLoadAnimation)
            {
                case PageAnimation.SlideAndFadeOutLeft:
                    await this.SlideAndFadeOutToLeft(this.SlideSeconds);
                    break;
            }
        }
        public async Task AnimateOutExit()
        {
            if (this.PageUnLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnLoadAnimation)
            {
                case PageAnimation.SlideAndFadeOutLeft:
                    await this.SlideAndFadeOutToLeft(this.SlideSeconds);
                    Application.Current.Shutdown();
                    break;
            }
        }

        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public PageAnimation PageUnLoadAnimation { get; set; } = PageAnimation.SlideAndFadeOutLeft;

        public float SlideSeconds { get; set; } = 0.4f;

        public bool ShouldAnimateOut { get; set; }

    }


    public class BasePage<VM> : BasePage
        where VM : BaseViewModel, new()
    {
        private VM mViewModel;       

        public VM ViewModel 
        {
            get { return mViewModel; }
            set 
            {
                if (mViewModel == value)
                    return;

                mViewModel = value;
                
              this.DataContext = mViewModel;
            }
        }

        public BasePage() :base()
        {
            this.ViewModel = new VM();
        }            
    }
}
