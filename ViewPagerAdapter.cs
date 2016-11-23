using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Java.Lang;
using UniversalImageLoader.Core;

namespace XamarinUniversalImageLoader
{
    class ViewPagerAdapter : PagerAdapter
    {
        private Activity activity;
        private List<string> listImages;
        private LayoutInflater inflater;
        private ImageLoader image_loader;

        public ViewPagerAdapter(Activity activity,List<string> listImages,ImageLoader image_loader)
        {
            this.activity = activity;
            this.listImages = listImages;
            this.image_loader = image_loader;
        }

        public override int Count
        {
            get
            {
                return listImages.Count;
            }
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object @object)
        {
            return view == @object;
        }


        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            inflater = (LayoutInflater)activity.BaseContext.GetSystemService(Context.LayoutInflaterService);
            View itemView = inflater.Inflate(Resource.Layout.viewpager_layout, container,false);

            ImageView image_content = itemView.FindViewById<ImageView>(Resource.Id.image_content);
            image_loader.DisplayImage(listImages[position], image_content);

            container.AddView(itemView);

            return itemView;
        }

        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object @object)
        {
            ((ViewPager)container).RemoveView((View)@object);
        }



    }
}