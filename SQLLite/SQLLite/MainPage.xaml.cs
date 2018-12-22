using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLLite
{
    public partial class MainPage : ContentPage
    {
      

        public MainPage()
        {
            InitializeComponent();
            
        }



        private void Getallpeople_Clicked(object sender, EventArgs e)
        {
            listpeople.ItemsSource = App.PersonRepo.GetAllPeople();

        }

        private void AddPeople_Clicked(object sender, EventArgs e)
        {
            App.PersonRepo.AddNewPerson(entrancy.Text);
        }
    }
}
