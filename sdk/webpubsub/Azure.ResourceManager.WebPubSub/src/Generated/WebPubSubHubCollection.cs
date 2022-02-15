// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.WebPubSub
{
    /// <summary> A class representing collection of WebPubSubHub and their operations over its parent. </summary>
    public partial class WebPubSubHubCollection : ArmCollection, IEnumerable<WebPubSubHub>, IAsyncEnumerable<WebPubSubHub>
    {
        private readonly ClientDiagnostics _webPubSubHubClientDiagnostics;
        private readonly WebPubSubHubsRestOperations _webPubSubHubRestClient;

        /// <summary> Initializes a new instance of the <see cref="WebPubSubHubCollection"/> class for mocking. </summary>
        protected WebPubSubHubCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="WebPubSubHubCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal WebPubSubHubCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _webPubSubHubClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.WebPubSub", WebPubSubHub.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(WebPubSubHub.ResourceType, out string webPubSubHubApiVersion);
            _webPubSubHubRestClient = new WebPubSubHubsRestOperations(_webPubSubHubClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, webPubSubHubApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != WebPubSub.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, WebPubSub.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update a hub setting.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/hubs/{hubName}
        /// Operation Id: WebPubSubHubs_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="hubName"> The hub name. </param>
        /// <param name="parameters"> The resource of WebPubSubHub and its properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hubName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hubName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<WebPubSubHub>> CreateOrUpdateAsync(bool waitForCompletion, string hubName, WebPubSubHubData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hubName, nameof(hubName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _webPubSubHubClientDiagnostics.CreateScope("WebPubSubHubCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _webPubSubHubRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hubName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new WebPubSubArmOperation<WebPubSubHub>(new WebPubSubHubOperationSource(Client), _webPubSubHubClientDiagnostics, Pipeline, _webPubSubHubRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hubName, parameters).Request, response, OperationFinalStateVia.Location);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update a hub setting.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/hubs/{hubName}
        /// Operation Id: WebPubSubHubs_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="hubName"> The hub name. </param>
        /// <param name="parameters"> The resource of WebPubSubHub and its properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hubName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hubName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<WebPubSubHub> CreateOrUpdate(bool waitForCompletion, string hubName, WebPubSubHubData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hubName, nameof(hubName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _webPubSubHubClientDiagnostics.CreateScope("WebPubSubHubCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _webPubSubHubRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hubName, parameters, cancellationToken);
                var operation = new WebPubSubArmOperation<WebPubSubHub>(new WebPubSubHubOperationSource(Client), _webPubSubHubClientDiagnostics, Pipeline, _webPubSubHubRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hubName, parameters).Request, response, OperationFinalStateVia.Location);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a hub setting.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/hubs/{hubName}
        /// Operation Id: WebPubSubHubs_Get
        /// </summary>
        /// <param name="hubName"> The hub name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hubName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hubName"/> is null. </exception>
        public async virtual Task<Response<WebPubSubHub>> GetAsync(string hubName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hubName, nameof(hubName));

            using var scope = _webPubSubHubClientDiagnostics.CreateScope("WebPubSubHubCollection.Get");
            scope.Start();
            try
            {
                var response = await _webPubSubHubRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hubName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _webPubSubHubClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new WebPubSubHub(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a hub setting.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/hubs/{hubName}
        /// Operation Id: WebPubSubHubs_Get
        /// </summary>
        /// <param name="hubName"> The hub name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hubName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hubName"/> is null. </exception>
        public virtual Response<WebPubSubHub> Get(string hubName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hubName, nameof(hubName));

            using var scope = _webPubSubHubClientDiagnostics.CreateScope("WebPubSubHubCollection.Get");
            scope.Start();
            try
            {
                var response = _webPubSubHubRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hubName, cancellationToken);
                if (response.Value == null)
                    throw _webPubSubHubClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new WebPubSubHub(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List hub settings.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/hubs
        /// Operation Id: WebPubSubHubs_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="WebPubSubHub" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<WebPubSubHub> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<WebPubSubHub>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _webPubSubHubClientDiagnostics.CreateScope("WebPubSubHubCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _webPubSubHubRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new WebPubSubHub(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<WebPubSubHub>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _webPubSubHubClientDiagnostics.CreateScope("WebPubSubHubCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _webPubSubHubRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new WebPubSubHub(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// List hub settings.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/hubs
        /// Operation Id: WebPubSubHubs_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="WebPubSubHub" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<WebPubSubHub> GetAll(CancellationToken cancellationToken = default)
        {
            Page<WebPubSubHub> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _webPubSubHubClientDiagnostics.CreateScope("WebPubSubHubCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _webPubSubHubRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new WebPubSubHub(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<WebPubSubHub> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _webPubSubHubClientDiagnostics.CreateScope("WebPubSubHubCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _webPubSubHubRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new WebPubSubHub(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/hubs/{hubName}
        /// Operation Id: WebPubSubHubs_Get
        /// </summary>
        /// <param name="hubName"> The hub name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hubName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hubName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string hubName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hubName, nameof(hubName));

            using var scope = _webPubSubHubClientDiagnostics.CreateScope("WebPubSubHubCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(hubName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/hubs/{hubName}
        /// Operation Id: WebPubSubHubs_Get
        /// </summary>
        /// <param name="hubName"> The hub name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hubName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hubName"/> is null. </exception>
        public virtual Response<bool> Exists(string hubName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hubName, nameof(hubName));

            using var scope = _webPubSubHubClientDiagnostics.CreateScope("WebPubSubHubCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(hubName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/hubs/{hubName}
        /// Operation Id: WebPubSubHubs_Get
        /// </summary>
        /// <param name="hubName"> The hub name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hubName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hubName"/> is null. </exception>
        public async virtual Task<Response<WebPubSubHub>> GetIfExistsAsync(string hubName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hubName, nameof(hubName));

            using var scope = _webPubSubHubClientDiagnostics.CreateScope("WebPubSubHubCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _webPubSubHubRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hubName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<WebPubSubHub>(null, response.GetRawResponse());
                return Response.FromValue(new WebPubSubHub(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/hubs/{hubName}
        /// Operation Id: WebPubSubHubs_Get
        /// </summary>
        /// <param name="hubName"> The hub name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hubName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hubName"/> is null. </exception>
        public virtual Response<WebPubSubHub> GetIfExists(string hubName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hubName, nameof(hubName));

            using var scope = _webPubSubHubClientDiagnostics.CreateScope("WebPubSubHubCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _webPubSubHubRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hubName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<WebPubSubHub>(null, response.GetRawResponse());
                return Response.FromValue(new WebPubSubHub(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<WebPubSubHub> IEnumerable<WebPubSubHub>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<WebPubSubHub> IAsyncEnumerable<WebPubSubHub>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
