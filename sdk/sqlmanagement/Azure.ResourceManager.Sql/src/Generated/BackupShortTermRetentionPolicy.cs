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
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A Class representing a BackupShortTermRetentionPolicy along with the instance operations that can be performed on it. </summary>
    public partial class BackupShortTermRetentionPolicy : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="BackupShortTermRetentionPolicy"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string policyName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/backupShortTermRetentionPolicies/{policyName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _backupShortTermRetentionPolicyClientDiagnostics;
        private readonly BackupShortTermRetentionPoliciesRestOperations _backupShortTermRetentionPolicyRestClient;
        private readonly BackupShortTermRetentionPolicyData _data;

        /// <summary> Initializes a new instance of the <see cref="BackupShortTermRetentionPolicy"/> class for mocking. </summary>
        protected BackupShortTermRetentionPolicy()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "BackupShortTermRetentionPolicy"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal BackupShortTermRetentionPolicy(ArmClient client, BackupShortTermRetentionPolicyData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="BackupShortTermRetentionPolicy"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal BackupShortTermRetentionPolicy(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _backupShortTermRetentionPolicyClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string backupShortTermRetentionPolicyApiVersion);
            _backupShortTermRetentionPolicyRestClient = new BackupShortTermRetentionPoliciesRestOperations(_backupShortTermRetentionPolicyClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, backupShortTermRetentionPolicyApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Sql/servers/databases/backupShortTermRetentionPolicies";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual BackupShortTermRetentionPolicyData Data
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
        /// Gets a database&apos;s short term retention policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/backupShortTermRetentionPolicies/{policyName}
        /// Operation Id: BackupShortTermRetentionPolicies_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<BackupShortTermRetentionPolicy>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _backupShortTermRetentionPolicyClientDiagnostics.CreateScope("BackupShortTermRetentionPolicy.Get");
            scope.Start();
            try
            {
                var response = await _backupShortTermRetentionPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _backupShortTermRetentionPolicyClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new BackupShortTermRetentionPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a database&apos;s short term retention policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/backupShortTermRetentionPolicies/{policyName}
        /// Operation Id: BackupShortTermRetentionPolicies_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<BackupShortTermRetentionPolicy> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _backupShortTermRetentionPolicyClientDiagnostics.CreateScope("BackupShortTermRetentionPolicy.Get");
            scope.Start();
            try
            {
                var response = _backupShortTermRetentionPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _backupShortTermRetentionPolicyClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BackupShortTermRetentionPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates a database&apos;s short term retention policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/backupShortTermRetentionPolicies/{policyName}
        /// Operation Id: BackupShortTermRetentionPolicies_Update
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="parameters"> The short term retention policy info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<BackupShortTermRetentionPolicy>> UpdateAsync(bool waitForCompletion, BackupShortTermRetentionPolicyData parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _backupShortTermRetentionPolicyClientDiagnostics.CreateScope("BackupShortTermRetentionPolicy.Update");
            scope.Start();
            try
            {
                var response = await _backupShortTermRetentionPolicyRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<BackupShortTermRetentionPolicy>(new BackupShortTermRetentionPolicyOperationSource(Client), _backupShortTermRetentionPolicyClientDiagnostics, Pipeline, _backupShortTermRetentionPolicyRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Updates a database&apos;s short term retention policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/backupShortTermRetentionPolicies/{policyName}
        /// Operation Id: BackupShortTermRetentionPolicies_Update
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="parameters"> The short term retention policy info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<BackupShortTermRetentionPolicy> Update(bool waitForCompletion, BackupShortTermRetentionPolicyData parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _backupShortTermRetentionPolicyClientDiagnostics.CreateScope("BackupShortTermRetentionPolicy.Update");
            scope.Start();
            try
            {
                var response = _backupShortTermRetentionPolicyRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, parameters, cancellationToken);
                var operation = new SqlArmOperation<BackupShortTermRetentionPolicy>(new BackupShortTermRetentionPolicyOperationSource(Client), _backupShortTermRetentionPolicyClientDiagnostics, Pipeline, _backupShortTermRetentionPolicyRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, parameters).Request, response, OperationFinalStateVia.Location);
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
    }
}
