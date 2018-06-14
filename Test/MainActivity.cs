using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Autofac;
using Test.Core;

namespace Test
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private ArrayAdapter<string> _adapter;
        private ListView _listView;

        public IDataStorage DataStorage { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Test app";

            DataStorage = MainApp.Container.Resolve<DataStorage>();

            _listView = FindViewById<ListView>(Resource.Id.list_view);
        }

        protected override void OnResume()
        {
            base.OnResume();

            //created like that for simplicity. best practice to use property changed in DataStorage implementation
            _adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, DataStorage.Persons);
            _listView.Adapter = _adapter;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_toolbar, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_back)
            {
                StartActivity(typeof(DetailActivity));
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}