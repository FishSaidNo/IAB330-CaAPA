package mono;

import java.io.*;
import java.lang.String;
import java.util.Locale;
import java.util.HashSet;
import java.util.zip.*;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.res.AssetManager;
import android.util.Log;
import mono.android.Runtime;

public class MonoPackageManager {

	static Object lock = new Object ();
	static boolean initialized;

	public static void LoadApplication (Context context, ApplicationInfo runtimePackage, String[] apks)
	{
		synchronized (lock) {
			if (!initialized) {
				System.loadLibrary("monodroid");
				Locale locale       = Locale.getDefault ();
				String language     = locale.getLanguage () + "-" + locale.getCountry ();
				String filesDir     = context.getFilesDir ().getAbsolutePath ();
				String cacheDir     = context.getCacheDir ().getAbsolutePath ();
				String dataDir      = getNativeLibraryPath (context);
				ClassLoader loader  = context.getClassLoader ();

				Runtime.init (
						language,
						apks,
						getNativeLibraryPath (runtimePackage),
						new String[]{
							filesDir,
							cacheDir,
							dataDir,
						},
						loader,
						new java.io.File (
							android.os.Environment.getExternalStorageDirectory (),
							"Android/data/" + context.getPackageName () + "/files/.__override__").getAbsolutePath (),
						MonoPackageManager_Resources.Assemblies,
						context.getPackageName ());
				initialized = true;
			}
		}
	}

	static String getNativeLibraryPath (Context context)
	{
	    return getNativeLibraryPath (context.getApplicationInfo ());
	}

	static String getNativeLibraryPath (ApplicationInfo ainfo)
	{
		if (android.os.Build.VERSION.SDK_INT >= 9)
			return ainfo.nativeLibraryDir;
		return ainfo.dataDir + "/lib";
	}

	public static String[] getAssemblies ()
	{
		return MonoPackageManager_Resources.Assemblies;
	}

	public static String[] getDependencies ()
	{
		return MonoPackageManager_Resources.Dependencies;
	}

	public static String getApiPackageName ()
	{
		return MonoPackageManager_Resources.ApiPackageName;
	}
}

class MonoPackageManager_Resources {
	public static final String[] Assemblies = new String[]{
		"CaAPA.Droid.dll",
		"AndroidAltBeaconLibrary.dll",
		"CaAPA.Data.dll",
		"CaAPA.dll",
		"FormsViewGroup.dll",
		"GalaSoft.MvvmLight.dll",
		"GalaSoft.MvvmLight.Extras.dll",
		"GalaSoft.MvvmLight.Platform.dll",
		"Microsoft.Practices.ServiceLocation.dll",
		"Microsoft.WindowsAzure.Mobile.dll",
		"Microsoft.WindowsAzure.Mobile.Ext.dll",
		"Microsoft.WindowsAzure.Mobile.SQLiteStore.dll",
		"Newtonsoft.Json.dll",
		"SQLite.Net.dll",
		"SQLite.Net.Platform.XamarinAndroid.dll",
		"SQLitePCL.dll",
		"SQLitePCL.Ext.dll",
		"System.Collections.dll",
		"System.IO.dll",
		"System.Linq.dll",
		"System.Linq.Expressions.dll",
		"System.Net.Http.Extensions.dll",
		"System.Net.Http.Primitives.dll",
		"System.Runtime.dll",
		"System.Threading.Tasks.dll",
		"Xamarin.Android.Support.v4.dll",
		"Xamarin.Forms.Core.dll",
		"Xamarin.Forms.Platform.Android.dll",
		"Xamarin.Forms.Platform.dll",
		"Xamarin.Forms.Xaml.dll",
		"System.Diagnostics.Debug.dll",
		"System.ObjectModel.dll",
		"System.Threading.dll",
		"System.Reflection.dll",
		"System.Diagnostics.Tools.dll",
		"System.Globalization.dll",
		"System.Runtime.Extensions.dll",
		"System.Reflection.Extensions.dll",
		"System.ComponentModel.dll",
		"System.Resources.ResourceManager.dll",
		"System.Text.RegularExpressions.dll",
		"System.Net.Primitives.dll",
		"System.Text.Encoding.dll",
		"System.Linq.Queryable.dll",
		"System.Runtime.Serialization.Primitives.dll",
		"System.Runtime.InteropServices.dll",
		"System.Xml.ReaderWriter.dll",
		"System.Dynamic.Runtime.dll",
	};
	public static final String[] Dependencies = new String[]{
	};
	public static final String ApiPackageName = "Mono.Android.Platform.ApiLevel_22";
}
