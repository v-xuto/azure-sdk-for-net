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

namespace Azure.ResourceManager.AppService
{
    /// <summary> A class representing collection of SiteDiagnosticAnalysis and their operations over its parent. </summary>
    public partial class SiteDiagnosticAnalysisCollection : ArmCollection, IEnumerable<SiteDiagnosticAnalysis>, IAsyncEnumerable<SiteDiagnosticAnalysis>
    {
        private readonly ClientDiagnostics _siteDiagnosticAnalysisDiagnosticsClientDiagnostics;
        private readonly DiagnosticsRestOperations _siteDiagnosticAnalysisDiagnosticsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SiteDiagnosticAnalysisCollection"/> class for mocking. </summary>
        protected SiteDiagnosticAnalysisCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SiteDiagnosticAnalysisCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SiteDiagnosticAnalysisCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _siteDiagnosticAnalysisDiagnosticsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", SiteDiagnosticAnalysis.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(SiteDiagnosticAnalysis.ResourceType, out string siteDiagnosticAnalysisDiagnosticsApiVersion);
            _siteDiagnosticAnalysisDiagnosticsRestClient = new DiagnosticsRestOperations(_siteDiagnosticAnalysisDiagnosticsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, siteDiagnosticAnalysisDiagnosticsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SiteDiagnostic.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SiteDiagnostic.ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Get Site Analysis
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/analyses/{analysisName}
        /// Operation Id: Diagnostics_GetSiteAnalysis
        /// </summary>
        /// <param name="analysisName"> Analysis Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="analysisName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="analysisName"/> is null. </exception>
        public async virtual Task<Response<SiteDiagnosticAnalysis>> GetAsync(string analysisName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(analysisName, nameof(analysisName));

            using var scope = _siteDiagnosticAnalysisDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticAnalysisCollection.Get");
            scope.Start();
            try
            {
                var response = await _siteDiagnosticAnalysisDiagnosticsRestClient.GetSiteAnalysisAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, analysisName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _siteDiagnosticAnalysisDiagnosticsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SiteDiagnosticAnalysis(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get Site Analysis
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/analyses/{analysisName}
        /// Operation Id: Diagnostics_GetSiteAnalysis
        /// </summary>
        /// <param name="analysisName"> Analysis Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="analysisName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="analysisName"/> is null. </exception>
        public virtual Response<SiteDiagnosticAnalysis> Get(string analysisName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(analysisName, nameof(analysisName));

            using var scope = _siteDiagnosticAnalysisDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticAnalysisCollection.Get");
            scope.Start();
            try
            {
                var response = _siteDiagnosticAnalysisDiagnosticsRestClient.GetSiteAnalysis(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, analysisName, cancellationToken);
                if (response.Value == null)
                    throw _siteDiagnosticAnalysisDiagnosticsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteDiagnosticAnalysis(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get Site Analyses
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/analyses
        /// Operation Id: Diagnostics_ListSiteAnalyses
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SiteDiagnosticAnalysis" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SiteDiagnosticAnalysis> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SiteDiagnosticAnalysis>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteDiagnosticAnalysisDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticAnalysisCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteDiagnosticAnalysisDiagnosticsRestClient.ListSiteAnalysesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteDiagnosticAnalysis(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SiteDiagnosticAnalysis>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteDiagnosticAnalysisDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticAnalysisCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteDiagnosticAnalysisDiagnosticsRestClient.ListSiteAnalysesNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteDiagnosticAnalysis(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Description for Get Site Analyses
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/analyses
        /// Operation Id: Diagnostics_ListSiteAnalyses
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SiteDiagnosticAnalysis" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SiteDiagnosticAnalysis> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SiteDiagnosticAnalysis> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteDiagnosticAnalysisDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticAnalysisCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteDiagnosticAnalysisDiagnosticsRestClient.ListSiteAnalyses(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteDiagnosticAnalysis(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SiteDiagnosticAnalysis> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteDiagnosticAnalysisDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticAnalysisCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteDiagnosticAnalysisDiagnosticsRestClient.ListSiteAnalysesNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteDiagnosticAnalysis(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/analyses/{analysisName}
        /// Operation Id: Diagnostics_GetSiteAnalysis
        /// </summary>
        /// <param name="analysisName"> Analysis Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="analysisName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="analysisName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string analysisName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(analysisName, nameof(analysisName));

            using var scope = _siteDiagnosticAnalysisDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticAnalysisCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(analysisName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/analyses/{analysisName}
        /// Operation Id: Diagnostics_GetSiteAnalysis
        /// </summary>
        /// <param name="analysisName"> Analysis Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="analysisName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="analysisName"/> is null. </exception>
        public virtual Response<bool> Exists(string analysisName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(analysisName, nameof(analysisName));

            using var scope = _siteDiagnosticAnalysisDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticAnalysisCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(analysisName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/analyses/{analysisName}
        /// Operation Id: Diagnostics_GetSiteAnalysis
        /// </summary>
        /// <param name="analysisName"> Analysis Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="analysisName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="analysisName"/> is null. </exception>
        public async virtual Task<Response<SiteDiagnosticAnalysis>> GetIfExistsAsync(string analysisName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(analysisName, nameof(analysisName));

            using var scope = _siteDiagnosticAnalysisDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticAnalysisCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _siteDiagnosticAnalysisDiagnosticsRestClient.GetSiteAnalysisAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, analysisName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SiteDiagnosticAnalysis>(null, response.GetRawResponse());
                return Response.FromValue(new SiteDiagnosticAnalysis(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/analyses/{analysisName}
        /// Operation Id: Diagnostics_GetSiteAnalysis
        /// </summary>
        /// <param name="analysisName"> Analysis Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="analysisName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="analysisName"/> is null. </exception>
        public virtual Response<SiteDiagnosticAnalysis> GetIfExists(string analysisName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(analysisName, nameof(analysisName));

            using var scope = _siteDiagnosticAnalysisDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticAnalysisCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _siteDiagnosticAnalysisDiagnosticsRestClient.GetSiteAnalysis(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, analysisName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SiteDiagnosticAnalysis>(null, response.GetRawResponse());
                return Response.FromValue(new SiteDiagnosticAnalysis(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SiteDiagnosticAnalysis> IEnumerable<SiteDiagnosticAnalysis>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SiteDiagnosticAnalysis> IAsyncEnumerable<SiteDiagnosticAnalysis>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
