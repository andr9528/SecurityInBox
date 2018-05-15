using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SecurityInAMobile
{
    class DeviceViewModel
    {
        private DeviceRepo _oldProduct;

        public ObservableCollection<DeviceRepo> DeviceRepos { get; set; }

        public Command<DeviceRepo> change
        {


            get
            {


                return new Command<DeviceRepo>((DeviceRepo) => DeviceRepo.Id = 1);
                //{
                //    //Console.WriteLine("" + product);
                //});
            }
        }


        public DeviceViewModel()
        {
            DeviceRepos = new ObservableCollection<DeviceRepo>
            {
                new DeviceRepo
                {
                    Approve = "Approve",
                    name="Atmar",
                    lastName = "Kohistany",
                    Id = 1,
                },
                new DeviceRepo
                {
                    Approve = "Approve",
                    name="Mursal",
                    lastName = "Yaqubi",
                    Id = 1,

                },
                new DeviceRepo
                {
                    Approve = "Approve",
                    name="Jazmin",
                    lastName = "Yaqubi-Kohistany",
                    Id = 1,

                }
            };
        }

        public void HideOrShowProduct(DeviceRepo deviceRepo)
        {
            deviceRepo.IsVisible = true;
            UpdateProduct(deviceRepo);
            _oldProduct = deviceRepo;

        }


        public void UpdateProduct(DeviceRepo deviceRepo)
        {
            if (deviceRepo.Id == 1 || deviceRepo.Id == 0)
            {

                var index = DeviceRepos.IndexOf(deviceRepo);
                DeviceRepos.Remove(deviceRepo);
                DeviceRepos.Insert(index, deviceRepo);
            }

        }
    }
}
