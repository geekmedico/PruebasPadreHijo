using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebasPadreHijo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HijaPage : ContentPage
    {
        Action<string> _callBack;
        public string Texto { get; set; } = string.Empty;
        public HijaPage()
        {
            InitializeComponent();
        }
        //Creamos este Constructor para poder iniciar nuestra página con el parametro que deseamos
        public HijaPage(Action<string> callBack)
        {
            InitializeComponent();
            _callBack = callBack;
            
        }

        private async void btnCerrar_Clicked(object sender, EventArgs e)
        {
            //Al seleccionar el boton cerrar, ejecutamos el metodo CallBack
            _callBack(txtTextoHijo.Text);
            await Navigation.PopAsync();
        }
        //Esta es otra forma de hacerlo
        //Así nos aseguramos de que en caso de que el usuario presione el botón físico de retroceso en android, se dispare CallBack
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //En este caso, necesitamos que el texto sea una propiedad de la HijaPage, para poder usarlo en la MainPage
            Texto = txtTextoHijo.Text;
            //O bien, podemos ejecutar CallBack
            //_callBack(txtTextoHijo.Text);
        }
    }
}