using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PatientXamarinApp.Models;
using PatientXamarinApp.Services;
using Xamarin.Forms;

namespace PatientXamarinApp.ViewModels
{
   public class PatientsViewModel : BaseViewModel
    {


        //public static class PatientObject

        //{
        //    public List<Patients> _patients { get; set; }
        //    public List<Genders> _Genders { get; set; }
        //    public List<BloodGroups> _BloodGroups { get; set; }
        //}



        private List<Patients> _patients;

        private List<Models.Genders> _Genders;
        private List<Models.BloodGroups> _BloodGroups;


        private DataServices _dataServices = new DataServices();
        private bool _isRefresh;


        //public List<Genders> _GendersList
        //{
        //    get { return _Genders; }
        //    set
        //    {

        //        _Genders = value;

        //        OnPropertyChanged("_GendersList");

        //    }

        //}

        public List<Patients> _patientsList
        {
            get
            {
                return _patients;

             
            }
            set
            {

                _patients = value;
                
                OnPropertyChanged();

            }
        }


    
        //public List<BloodGroups> _BloodGroupsList
        //{
        //    get { return _BloodGroups; }
        //    set
        //    {

        //        _BloodGroups = value;

        //        OnPropertyChanged("_BloodGroupsList");

        //    }

        //}

        public PatientsViewModel()
        {
           


            GetPatients().ConfigureAwait(false);
        

        }

        public bool isRefresh
        {
            get { return _isRefresh; }
            set
            {
                _isRefresh = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetPatientsCommand => new Command(async () =>

        {
            
               GetPatients();

         
        });


        private async Task GetPatients()

        {
            isRefresh = true;

            //var task2 = Task.Run(async () => await _dataServices.GetBloodGroup().ConfigureAwait(false));
            //_BloodGroupsList = task2.Result;

            //var task = Task.Run(async () => await _dataServices.GetGenders().ConfigureAwait(false));

            //_GendersList = task.Result;
            //_BloodGroupsList = await _dataServices.GetBloodGroup().ConfigureAwait(false);
            //_GendersList = await _dataServices.GetGenders().ConfigureAwait(false);

            _patientsList = await _dataServices.GetPatients().ConfigureAwait(false);
            isRefresh = false;
        }



        




    }
}
