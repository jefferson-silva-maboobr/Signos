package md52c1a2ecc2d36b18d7e812608e4fa010b;


public class StyledLabelRenderer
	extends md5530bd51e982e6e7b340b73e88efe666e.LabelRenderer
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Customization.Droid.StyledLabelRenderer, Signos.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", StyledLabelRenderer.class, __md_methods);
	}


	public StyledLabelRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == StyledLabelRenderer.class)
			mono.android.TypeManager.Activate ("Customization.Droid.StyledLabelRenderer, Signos.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public StyledLabelRenderer (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == StyledLabelRenderer.class)
			mono.android.TypeManager.Activate ("Customization.Droid.StyledLabelRenderer, Signos.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public StyledLabelRenderer (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == StyledLabelRenderer.class)
			mono.android.TypeManager.Activate ("Customization.Droid.StyledLabelRenderer, Signos.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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
