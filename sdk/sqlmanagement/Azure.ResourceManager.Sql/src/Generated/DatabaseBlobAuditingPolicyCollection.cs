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
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class representing collection of DatabaseBlobAuditingPolicy and their operations over its parent. </summary>
    public partial class DatabaseBlobAuditingPolicyCollection : ArmCollection, IEnumerable<DatabaseBlobAuditingPolicy>, IAsyncEnumerable<DatabaseBlobAuditingPolicy>
    {
        private readonly ClientDiagnostics _databaseBlobAuditingPolicyClientDiagnostics;
        private readonly DatabaseBlobAuditingPoliciesRestOperations _databaseBlobAuditingPolicyRestClient;

        /// <summary> Initializes a new instance of the <see cref="DatabaseBlobAuditingPolicyCollection"/> class for mocking. </summary>
        protected DatabaseBlobAuditingPolicyCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DatabaseBlobAuditingPolicyCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DatabaseBlobAuditingPolicyCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _databaseBlobAuditingPolicyClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", DatabaseBlobAuditingPolicy.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(DatabaseBlobAuditingPolicy.ResourceType, out string databaseBlobAuditingPolicyApiVersion);
            _databaseBlobAuditingPolicyRestClient = new DatabaseBlobAuditingPoliciesRestOperations(_databaseBlobAuditingPolicyClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, databaseBlobAuditingPolicyApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SqlDatabase.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SqlDatabase.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a database&apos;s blob auditing policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/auditingSettings/{blobAuditingPolicyName}
        /// Operation Id: DatabaseBlobAuditingPolicies_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="blobAuditingPolicyName"> The name of the blob auditing policy. </param>
        /// <param name="parameters"> The database blob auditing policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<DatabaseBlobAuditingPolicy>> CreateOrUpdateAsync(bool waitForCompletion, BlobAuditingPolicyName blobAuditingPolicyName, DatabaseBlobAuditingPolicyData parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _databaseBlobAuditingPolicyClientDiagnostics.CreateScope("DatabaseBlobAuditingPolicyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _databaseBlobAuditingPolicyRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, blobAuditingPolicyName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<DatabaseBlobAuditingPolicy>(Response.FromValue(new DatabaseBlobAuditingPolicy(Client, response), response.GetRawResponse()));
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
        /// Creates or updates a database&apos;s blob auditing policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/auditingSettings/{blobAuditingPolicyName}
        /// Operation Id: DatabaseBlobAuditingPolicies_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="blobAuditingPolicyName"> The name of the blob auditing policy. </param>
        /// <param name="parameters"> The database blob auditing policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<DatabaseBlobAuditingPolicy> CreateOrUpdate(bool waitForCompletion, BlobAuditingPolicyName blobAuditingPolicyName, DatabaseBlobAuditingPolicyData parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _databaseBlobAuditingPolicyClientDiagnostics.CreateScope("DatabaseBlobAuditingPolicyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _databaseBlobAuditingPolicyRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, blobAuditingPolicyName, parameters, cancellationToken);
                var operation = new SqlArmOperation<DatabaseBlobAuditingPolicy>(Response.FromValue(new DatabaseBlobAuditingPolicy(Client, response), response.GetRawResponse()));
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
        /// Gets a database&apos;s blob auditing policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/auditingSettings/{blobAuditingPolicyName}
        /// Operation Id: DatabaseBlobAuditingPolicies_Get
        /// </summary>
        /// <param name="blobAuditingPolicyName"> The name of the blob auditing policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<DatabaseBlobAuditingPolicy>> GetAsync(BlobAuditingPolicyName blobAuditingPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _databaseBlobAuditingPolicyClientDiagnostics.CreateScope("DatabaseBlobAuditingPolicyCollection.Get");
            scope.Start();
            try
            {
                var response = await _databaseBlobAuditingPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, blobAuditingPolicyName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _databaseBlobAuditingPolicyClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new DatabaseBlobAuditingPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a database&apos;s blob auditing policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/auditingSettings/{blobAuditingPolicyName}
        /// Operation Id: DatabaseBlobAuditingPolicies_Get
        /// </summary>
        /// <param name="blobAuditingPolicyName"> The name of the blob auditing policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DatabaseBlobAuditingPolicy> Get(BlobAuditingPolicyName blobAuditingPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _databaseBlobAuditingPolicyClientDiagnostics.CreateScope("DatabaseBlobAuditingPolicyCollection.Get");
            scope.Start();
            try
            {
                var response = _databaseBlobAuditingPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, blobAuditingPolicyName, cancellationToken);
                if (response.Value == null)
                    throw _databaseBlobAuditingPolicyClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DatabaseBlobAuditingPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists auditing settings of a database.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/auditingSettings
        /// Operation Id: DatabaseBlobAuditingPolicies_ListByDatabase
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DatabaseBlobAuditingPolicy" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DatabaseBlobAuditingPolicy> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DatabaseBlobAuditingPolicy>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _databaseBlobAuditingPolicyClientDiagnostics.CreateScope("DatabaseBlobAuditingPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _databaseBlobAuditingPolicyRestClient.ListByDatabaseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DatabaseBlobAuditingPolicy(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DatabaseBlobAuditingPolicy>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _databaseBlobAuditingPolicyClientDiagnostics.CreateScope("DatabaseBlobAuditingPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _databaseBlobAuditingPolicyRestClient.ListByDatabaseNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DatabaseBlobAuditingPolicy(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists auditing settings of a database.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/auditingSettings
        /// Operation Id: DatabaseBlobAuditingPolicies_ListByDatabase
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DatabaseBlobAuditingPolicy" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DatabaseBlobAuditingPolicy> GetAll(CancellationToken cancellationToken = default)
        {
            Page<DatabaseBlobAuditingPolicy> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _databaseBlobAuditingPolicyClientDiagnostics.CreateScope("DatabaseBlobAuditingPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _databaseBlobAuditingPolicyRestClient.ListByDatabase(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DatabaseBlobAuditingPolicy(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DatabaseBlobAuditingPolicy> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _databaseBlobAuditingPolicyClientDiagnostics.CreateScope("DatabaseBlobAuditingPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _databaseBlobAuditingPolicyRestClient.ListByDatabaseNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DatabaseBlobAuditingPolicy(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/auditingSettings/{blobAuditingPolicyName}
        /// Operation Id: DatabaseBlobAuditingPolicies_Get
        /// </summary>
        /// <param name="blobAuditingPolicyName"> The name of the blob auditing policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<bool>> ExistsAsync(BlobAuditingPolicyName blobAuditingPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _databaseBlobAuditingPolicyClientDiagnostics.CreateScope("DatabaseBlobAuditingPolicyCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(blobAuditingPolicyName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/auditingSettings/{blobAuditingPolicyName}
        /// Operation Id: DatabaseBlobAuditingPolicies_Get
        /// </summary>
        /// <param name="blobAuditingPolicyName"> The name of the blob auditing policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(BlobAuditingPolicyName blobAuditingPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _databaseBlobAuditingPolicyClientDiagnostics.CreateScope("DatabaseBlobAuditingPolicyCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(blobAuditingPolicyName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/auditingSettings/{blobAuditingPolicyName}
        /// Operation Id: DatabaseBlobAuditingPolicies_Get
        /// </summary>
        /// <param name="blobAuditingPolicyName"> The name of the blob auditing policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<DatabaseBlobAuditingPolicy>> GetIfExistsAsync(BlobAuditingPolicyName blobAuditingPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _databaseBlobAuditingPolicyClientDiagnostics.CreateScope("DatabaseBlobAuditingPolicyCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _databaseBlobAuditingPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, blobAuditingPolicyName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<DatabaseBlobAuditingPolicy>(null, response.GetRawResponse());
                return Response.FromValue(new DatabaseBlobAuditingPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/auditingSettings/{blobAuditingPolicyName}
        /// Operation Id: DatabaseBlobAuditingPolicies_Get
        /// </summary>
        /// <param name="blobAuditingPolicyName"> The name of the blob auditing policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DatabaseBlobAuditingPolicy> GetIfExists(BlobAuditingPolicyName blobAuditingPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _databaseBlobAuditingPolicyClientDiagnostics.CreateScope("DatabaseBlobAuditingPolicyCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _databaseBlobAuditingPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, blobAuditingPolicyName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<DatabaseBlobAuditingPolicy>(null, response.GetRawResponse());
                return Response.FromValue(new DatabaseBlobAuditingPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DatabaseBlobAuditingPolicy> IEnumerable<DatabaseBlobAuditingPolicy>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DatabaseBlobAuditingPolicy> IAsyncEnumerable<DatabaseBlobAuditingPolicy>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
