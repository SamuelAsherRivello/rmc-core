using System;
using System.Collections.Generic;
using RMC.Core.DesignPatterns.Creational.Singleton.CustomSingletonMonobehaviour;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Audio;

namespace RMC.Core.Audio
{
	/// <summary>
	/// Maintain a list of AudioSources and play the next 
	/// AudioClip on the first available AudioSource.
	/// </summary>
	public class SoundManager : SingletonMonobehaviour<SoundManager>
	{
		// Properties -------------------------------------
		public List<AudioClip> AudioClips { get { return _soundManagerConfiguration.AudioClips; } }
		
		/// <summary>
		/// LIMITATION: The current implementation of <see cref="SoundManager"/> puts all audio
		/// into one master group. If you want separate groups (e.g. SFX vs Music), update the
		/// implementation.
		/// </summary>
		public AudioMixerGroup MasterAudioMixerGroup { get { return _soundManagerConfiguration.AudioMixer.FindMatchingGroups("Master")[0]; } }
		
		public Volume MasterVolume { get { return _masterVolume;}}
		
		// Fields -----------------------------------------
		[Header("References (Project)")]
		[SerializeField]
		private SoundManagerConfiguration _soundManagerConfiguration = null;

		[SerializeField]
		private List<AudioSource> _audioSources = new List<AudioSource>();
		private const string _MasterVolume = "MasterVolume"; //Must match the AudioMixer assets settings
		private Volume _masterVolume;
		
		// Unity Methods ----------------------------------
		protected void Start()
		{
			_masterVolume = new Volume(MasterAudioMixerGroup, "MasterVolume", 1);
			
			// Data
			Assert.IsNotNull(_soundManagerConfiguration);
			Assert.IsNotNull(_soundManagerConfiguration.AudioClips);
			Assert.IsTrue(_soundManagerConfiguration.AudioClips.Count > 0);
			Assert.IsNotNull(_soundManagerConfiguration.AudioMixer);
			
			// Structure
			Assert.IsTrue(_audioSources.Count > 0);
			AssignAudioMixerToAllAudioSources();
		}
		

		// General Methods --------------------------------
		/// <summary>
		/// This is called on start.
		///
		/// Optional: You can also call it with the right click menu
		///				per ContextMenu at edit time and bake this into the prefab.
		/// </summary>
		[ContextMenu("Assign AudioMixer To All AudioSources")]
		public void AssignAudioMixerToAllAudioSources()
		{
			// Put all AudioSources into one group (Thus, same volume/pitch). 
			foreach (AudioSource audioSource in _audioSources)
			{
				audioSource.outputAudioMixerGroup = MasterAudioMixerGroup;
			}
		}
		
		
		/// <summary>
		/// Play the AudioClip by index.
		/// </summary>
		public void PlayAudioClip(int audioClipIndex)
		{
			AudioClip audioClip = null;
			try
			{
				audioClip = AudioClips[audioClipIndex];
			}
			catch
			{
				throw new ArgumentException($"PlayAudioClip() failed for index = {audioClipIndex}");
			}
			
			PlayAudioClip(audioClip);
		}

		
		/// <summary>
		/// Play the AudioClip by reference.
		/// If all sources are occupied, nothing will play.
		/// </summary>
		private void PlayAudioClip(AudioClip audioClip)
		{
			foreach (AudioSource audioSource in _audioSources)
			{
				if (!audioSource.isPlaying)
				{

					audioSource.clip = audioClip;
					audioSource.Play();
					return;
				}
			}
		}
		
		
		// Event Handlers ---------------------------------
	}
}