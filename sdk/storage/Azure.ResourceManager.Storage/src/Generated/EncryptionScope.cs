// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Storage
{
    /// <summary> A Class representing a EncryptionScope along with the instance operations that can be performed on it. </summary>
    public partial class EncryptionScope : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="EncryptionScope"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string encryptionScopeName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _encryptionScopeClientDiagnostics;
        private readonly EncryptionScopesRestOperations _encryptionScopeRestClient;
        private readonly EncryptionScopeData _data;

        /// <summary> Initializes a new instance of the <see cref="EncryptionScope"/> class for mocking. </summary>
        protected EncryptionScope()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "EncryptionScope"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal EncryptionScope(ArmClient client, EncryptionScopeData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="EncryptionScope"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal EncryptionScope(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _encryptionScopeClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Storage", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string encryptionScopeApiVersion);
            _encryptionScopeRestClient = new EncryptionScopesRestOperations(_encryptionScopeClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, encryptionScopeApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Storage/storageAccounts/encryptionScopes";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual EncryptionScopeData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Returns the properties for the specified encryption scope.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// Operation Id: EncryptionScopes_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<EncryptionScope>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _encryptionScopeClientDiagnostics.CreateScope("EncryptionScope.Get");
            scope.Start();
            try
            {
                var response = await _encryptionScopeRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _encryptionScopeClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new EncryptionScope(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns the properties for the specified encryption scope.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// Operation Id: EncryptionScopes_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<EncryptionScope> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _encryptionScopeClientDiagnostics.CreateScope("EncryptionScope.Get");
            scope.Start();
            try
            {
                var response = _encryptionScopeRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _encryptionScopeClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new EncryptionScope(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Update encryption scope properties as specified in the request body. Update fails if the specified encryption scope does not already exist.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// Operation Id: EncryptionScopes_Patch
        /// </summary>
        /// <param name="encryptionScope"> Encryption scope properties to be used for the update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScope"/> is null. </exception>
        public async virtual Task<Response<EncryptionScope>> UpdateAsync(EncryptionScopeData encryptionScope, CancellationToken cancellationToken = default)
        {
            if (encryptionScope == null)
            {
                throw new ArgumentNullException(nameof(encryptionScope));
            }

            using var scope = _encryptionScopeClientDiagnostics.CreateScope("EncryptionScope.Update");
            scope.Start();
            try
            {
                var response = await _encryptionScopeRestClient.PatchAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, encryptionScope, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new EncryptionScope(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Update encryption scope properties as specified in the request body. Update fails if the specified encryption scope does not already exist.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// Operation Id: EncryptionScopes_Patch
        /// </summary>
        /// <param name="encryptionScope"> Encryption scope properties to be used for the update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScope"/> is null. </exception>
        public virtual Response<EncryptionScope> Update(EncryptionScopeData encryptionScope, CancellationToken cancellationToken = default)
        {
            if (encryptionScope == null)
            {
                throw new ArgumentNullException(nameof(encryptionScope));
            }

            using var scope = _encryptionScopeClientDiagnostics.CreateScope("EncryptionScope.Update");
            scope.Start();
            try
            {
                var response = _encryptionScopeRestClient.Patch(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, encryptionScope, cancellationToken);
                return Response.FromValue(new EncryptionScope(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
