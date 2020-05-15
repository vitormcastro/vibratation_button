using Android.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace vibratation_button
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int time = 500;
        public MainPage()
        {
            InitializeComponent();
            txtValue.Text = time.ToString();
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                
                // Or use specified time
                var duration = TimeSpan.FromSeconds(time);
                Vibration.Vibrate(duration);
            }
            catch (FeatureNotSupportedException ex)
            {
                string message = ex.Message;
                Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
            }
        }

        private void txtValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtValue.Text))
                try
                {
                    int t = Convert.ToInt32(txtValue.Text);
                    if (t > 0)
                    {
                        time = t;
                    }
                }
                finally
                {
                    txtValue.Text = time.ToString();
                }
        }
    }
}
