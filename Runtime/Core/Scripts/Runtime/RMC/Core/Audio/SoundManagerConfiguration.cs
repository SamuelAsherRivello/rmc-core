using System.Collections.Generic;
using RMC.Core.Data.Types;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

namespace RMC.Core.Audio
{
	/// <summary>
	/// Maintain a list of AudioSources and play the next 
	/// AudioClip on the first available AudioSource.
	/// </summary>
	[CreateAssetMenu( menuName = CoreConstants.PathCoreCreateAssetMenu + Title,  fileName = Title, order = CoreConstants.PriorityTools_Primary)]
	public class SoundManagerConfiguration: ScriptableSingleton<SoundManagerConfiguration>
	{
	 	// Properties -------------------------------------
		public List<AudioClip> AudioClips { get { return _audioClips; } }
		public AudioMixer AudioMixer { get { return _audioMixer; } }
		
		//  Fields ----------------------------------------
		private const string Title = "SoundManagerConfiguration";

		[SerializeField] 
		private AudioMixer _audioMixer;

		
		[SerializeField]
		private List<AudioClip> _audioClips = new List<AudioClip>();

	}
}