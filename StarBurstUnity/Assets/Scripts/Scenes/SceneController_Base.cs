using UnityEngine;
using System.Collections;

abstract public class SceneController_Base : MonoBehaviour 
{
	abstract public RJWard.Core.RWSceneManager.EScene Scene ();

	static private SceneController_Base current_;
	static public SceneController_Base Current
	{
		get { return current_; }
	}

	void Awake()
	{
		current_ = this;
		PostAwake( );
		/*
		if (!SqliteUtils.IsInitialised( ))
		{
			if (SqliteUtils.DEBUG_SQL)
			{
				Debug.Log( "No SqliteUtils in " + this.GetType( ).ToString( ) );
			}
			SqliteUtils.Instance.databaseLoadComplete += OnDatabasesLoaded;
			SqliteUtils.Instance.initialiseDatabases( "English" );
		}
		else
		{
			OnDatabasesLoaded( );
		}*/
	}

	void Start () 
	{
		if (RJWard.Core.RWSceneManager.DEBUG_SCENES)
		{
			Debug.Log ("Scene " + Scene() + " Start");
		}
		RJWard.Core.RWSceneManager.Instance.HandleSceneAwake (this);

		PostStart ();
		RJWard.Core.RWSceneManager.Instance.finishedSwitching ();
		Handheld.StopActivityIndicator ();
	}

	// Override in subclasses for set-up
	protected virtual void PostStart()
	{
	}

	// Override in subclasses for set-up
	protected virtual void PostAwake()
	{
	}

	/*
	// Override in subclasses for set-up
	protected virtual void OnDatabasesLoaded( )
	{
		SqliteUtils.Instance.databaseLoadComplete -= OnDatabasesLoaded;
	}
	*/


}
