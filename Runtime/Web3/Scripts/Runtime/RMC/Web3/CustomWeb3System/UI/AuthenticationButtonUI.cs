using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using RMC.Core.UI;
using RMC.Web3.CustomWeb3System.CustomWeb3System;
using RMC.Web3.CustomWeb3System.Data.Types;
using UnityEngine;

namespace RMC.Web3.CustomWeb3System.UI
{
    /// <summary>
    /// Automatically handles authentication messaging on top of a button
    /// </summary>
    public class AuthenticationButtonUI : ButtonUI
    {
        //  Properties  ---------------------------------------
        private bool _hasCalledAuthenticate = false;
        //
        private static readonly string Deauthenticate = $"Deauthenticate\n({0})";
        private static readonly string Authenticate = $"Authenticate";
        private static readonly string Loading = $"Loading ...";
        
        
        private ICustomWeb3System CustomWeb3System { set; get; }

        private async UniTask<bool> AuthenticateAndReturnBoolAsync()
        {
            if (!_isAuthenticated)
            {
                await CustomWeb3System.AuthenticateAsync();
                _isAuthenticated = CustomWeb3System.IsAuthenticated;
                _hasCalledAuthenticate = true;
            }
            return _isAuthenticated;
        }
      
        //  Fields  ---------------------------------------
        private bool _isAuthenticated = false;
        
        //  Unity Methods  --------------------------------
        public async void Awake()
        {
            await CheckIsAuthenticatedAsync();
        }
        
        //  General Methods -------------------------------
        private async Task CheckIsAuthenticatedAsync()
        {
            //Don't set auth value
            _hasCalledAuthenticate = false;
            await RefreshUI();
            await AuthenticateAndReturnBoolAsync();
            await RefreshUI();
        }
        
        private async Task RefreshUI()
        {
            IsInteractable = true;
            
            if (_isAuthenticated)
            {
                try
                {
                    Address userAddress = await CustomWeb3System.GetUserAddressAsync();
                    string userAddressShortFormat = userAddress.ToShortFormat();
                    Text.text = string.Format(Deauthenticate, userAddressShortFormat);
                }
                catch (Exception exception)
                {
                    Debug.LogWarning("RefreshUI() failed " + exception.Message);
                    Text.text = Authenticate;
                }
            }
            else
            {
                // Fallback
                if (_hasCalledAuthenticate)
                {
                    Text.text = Authenticate;
                }
                else
                {
                    Text.text = Loading;
                    IsInteractable = false;
                }
            }
        }
		
        //  Event Handlers --------------------------------

    }
}