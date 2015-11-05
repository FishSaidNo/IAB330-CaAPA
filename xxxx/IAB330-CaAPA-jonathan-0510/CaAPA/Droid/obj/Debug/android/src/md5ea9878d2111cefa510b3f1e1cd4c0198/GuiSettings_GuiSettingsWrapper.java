package md5ea9878d2111cefa510b3f1e1cd4c0198;


public class GuiSettings_GuiSettingsWrapper
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("caapa.GuiSettings/GuiSettingsWrapper, CaAPA.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", GuiSettings_GuiSettingsWrapper.class, __md_methods);
	}


	public GuiSettings_GuiSettingsWrapper () throws java.lang.Throwable
	{
		super ();
		if (getClass () == GuiSettings_GuiSettingsWrapper.class)
			mono.android.TypeManager.Activate ("caapa.GuiSettings/GuiSettingsWrapper, CaAPA.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
