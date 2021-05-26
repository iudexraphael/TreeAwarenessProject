using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeAwareness.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TreeAwareness.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Catalogue : ContentPage
    {
        ObservableCollection<PlantCatalogue> classification1 = new ObservableCollection<PlantCatalogue>();
        public ObservableCollection<PlantCatalogue> Classification { get { return Classification; } }

        public Catalogue()
        {
            InitializeComponent();
            PlantView.ItemsSource = classification1;


            classification1.Add(new PlantCatalogue { 
                TreeCode = 1 , 
                Name = "Ataulfo Mango",
                InitialIdentification = "FLAVOR: Sweet and sour with tropical fruit notes. Honey mangos have a very small seed,so there is a high flesh to seed ratio.",
                Notes = "Aroma: Tropical fruit and peachy notes",
                GPSCoordinates = "1.8312° S, 78.1834° W",
                Location = "Mexico",
                Landmark = "Sinaloa",
                Height = "6.096 meters",
                Canopy = "Shady",
                Image = "ataulfo.jpg" });


            classification1.Add(new PlantCatalogue
            {
                TreeCode = 2,
                Name = "Tommy Atkins Mango",
                InitialIdentification = "FLAVOR: Tart with sweet notes..",
                Notes = " Texture: Smooth,firm flesh with no fibers",
                GPSCoordinates = "27.6648° N, 81.5158° W",
                Location = "United States of America",
                Landmark = "Florida",
                Height = "10-12 feet",
                Canopy = "Shady",
                Image = "tommyatkins.jpg"
            });

            classification1.Add(new PlantCatalogue
            {
                TreeCode = 3,
                Name = "Francis Mango",
                InitialIdentification = "FLAVOR: Sweet and fruity. The Francis mango grows on small farms throughout Haiti..",
                Notes = "Aroma: Tropical fruit and peachy notes",
                GPSCoordinates = "18.9712° N, 72.2852° W",
                Location = "Southeast Asia",
                Landmark = "Haiti",
                Height = "15 feet",
                Canopy = "5.5m and 5.8m",
                Image = "francismango.jpg"
            });
        }
    }
}