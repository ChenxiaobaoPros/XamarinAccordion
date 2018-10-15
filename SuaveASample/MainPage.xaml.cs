using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SuaveASample
{
    public partial class MainPage : ContentPage
    {
        private TapGestureRecognizer tg;

        public MainPage()
        {
            InitializeComponent();
            answerStack.IsVisible = false;

            tg = new TapGestureRecognizer();
            tg.Tapped += Tg_Tapped;
            questionStack.GestureRecognizers.Add(tg);
        }

        public Animation animate;

        void Tg_Tapped(object sender, EventArgs e)
        {
            var answerHeight = answerStack.Height;

            answerStack.IsVisible = !answerStack.IsVisible;
            questionStack.GestureRecognizers.Remove(tg);

            animate = new Animation(d => answerStack.HeightRequest = d, 0, answerHeight);

            animate.Commit(answerStack, "a", 5, 350, Easing.CubicIn, (data, x) => {
                Device.BeginInvokeOnMainThread(() => {
                    answerStack.HeightRequest = answerHeight;
                    questionStack.GestureRecognizers.Add(tg);
                });
            }, null);
        }
    }
}
