using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PruebasPadreHijo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnAbrirHija_Clicked(object sender, EventArgs e)
        {
            //Esta es una forma, primer creamos una instancia de HijaPage y no necesitamos pasar CallBack como un parametro
            //Así nos suscribimos al evento Disappearing de HijaPage
            //este evento se llamará cuando HijaPage se cierre
            HijaPage nuevaPagina = new HijaPage();
            nuevaPagina.Disappearing += NuevaPagina_Disappearing;
            await Navigation.PushAsync(nuevaPagina);


            //Otra forma sería crear la instancia cuando llamamos a presentarla y pasar CallBack como parametro
            //await Navigation.PushAsync(new HijaPage(CallBack));

            //Otra forma puede ser crear la instancia HijaPage y pasar CallBack como un parametro
            //Sin suscribirnos al evento Disappearing
            //HijaPage nuevaPagina = new HijaPage(CallBack);
            //await Navigation.PushAsync(nuevaPagina);
        }

        private void NuevaPagina_Disappearing(object sender, EventArgs e)
        {
            if (sender is HijaPage hijaPage)
            {
                CallBack(hijaPage.Texto);
                hijaPage.Disappearing -= NuevaPagina_Disappearing;
                //Nos desuscribimos del evento
            }
            
        }

        //Para ejemplificar uso un parametro string, pero puede ser un modelo que tu determines
        public void CallBack(string texto)
        {
            txtTexto.Text = texto;
        }
    }
}
