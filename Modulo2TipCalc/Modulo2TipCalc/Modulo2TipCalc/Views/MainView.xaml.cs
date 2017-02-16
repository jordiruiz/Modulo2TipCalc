using Modulo2TipCalc.ViewModels;

using Xamarin.Forms;

namespace Modulo2TipCalc.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }
    }
}
