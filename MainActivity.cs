using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using UniversalImageLoader.Core;
using System;
using Android.Support.V7.App;
using Android.Support.V4.View;

namespace XamarinUniversalImageLoader
{
    [Activity(Label = "XamarinUniversalImageLoader", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        private List<string> listImages = new List<string>();
        private ImageLoader image_loader;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);

            InitImages();

            var pager = FindViewById<ViewPager>(Resource.Id.pager);
            image_loader = ImageLoader.Instance;
            image_loader.Init(ImageLoaderConfiguration.CreateDefault(BaseContext));

            var adapter = new ViewPagerAdapter(this, listImages, image_loader);
            pager.Adapter = adapter;

        }

        private void InitImages()
        {
            listImages.Add("http://wallpaper21.com/wp-content/uploads/2016/06/android-phone-wallpapers10-576x1024.jpg");
            listImages.Add("http://wallpaper21.com/wp-content/uploads/2016/06/android-phone-wallpapers9.jpg");
            listImages.Add("http://wallpaper21.com/wp-content/uploads/2016/06/android-phone-wallpapers8-576x1024.jpg");
            listImages.Add("http://wallpaper21.com/wp-content/uploads/2016/06/android-phone-wallpapers7-576x1024.jpg");

        }
    }
}

