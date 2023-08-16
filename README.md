# Pirichain-api-csharp

Package for Pirichain API calls through Delphi 10
============

Pirichain is blockchain system that based on dPos (Delegated Proof of Stake) and has it own environment to create wallet and token, transactions, sending or storing data as a transaction, delegation.


Requirements
------------

* Delphi 10+ IDE


Usage
------------

The unit consists of 2 use cases, using the Indy-IdHTTP component, or System.Net.HttpClient.

### To use Indy-IdHTTP:

    Uses
        piriHelper_IdHTTP, ...;
  
    ...

    var
        Piri_id: TPiri_id;
    begin
        Piri_id := TPiri_id.Create(true);
    ...


### To use System.Net.HttpClient: 

    Uses
        piriHelper_HTTPClient, ...;

    ...

    var
        Piri_HTTP: TPiri_HTTP;
    begin
        Piri_HTTP := TPiri_HTTP.Create(true);
    ...


### Read the full list of commands below:


```delphi
var
  Piri_id: TPiri_id;
begin
  Piri_id := TPiri_id.Create(true);
  try
    response := Piri_id.createNewAddress('english', false);
    response := Piri_id.rescuePrivateKey
      ('entry frequent airport firm document close human roof fix pond popular laugh banner fruit faint exact sleep axis pipe crush today elder inform saddle');
    response := Piri_id.getMnemonic
      ('4bab94162ba406575bb5dd5814faa0bec124bb947a72cb221e951a8e348e9ce5');
    response := Piri_id.getBalance
      ('PRTMRWG479eCmbbufg92qZsysYHMH7bRL7H6eDVwNSx', '-1');
    response := Piri_id.getBalanceList
      ('PRTMRgoFporAfQYrNNJfj3Go37FT5AR3ueKCwpdKd1s');
    response := Piri_id.getToken('-1');
    response := Piri_id.listTokens();
    response := Piri_id.getScenario
      ('PRTMQ7fcZp7ACGDEom4KJQ4bvJ5nwQ3CcaUTFy642mE');
    response := Piri_id.listMyScenarios
      ('PRTMPUAV2mTGq6Dpu9ZBYmJyXWdt9RYiiouvRaZ8xUR');
    response := Piri_id.listScenarios();
    response := Piri_id.executeScenario
      ('PRTMPBjj3sutTtHwvRgB8YFHtMdcTv1Bd7cMWMxMrZP',
      'PRTMRWG479eCmbbufg92qZsysYHMH7bRL7H6eDVwNSx',
      '9d656610ec7ff8a8e7e9225234ee54b6fa31d147981e1b91106ce901ae69bf00',
      'init', '["11","22","333"]');
    response := Piri_id.previewScenario('{}',
      'PRTMRWG479eCmbbufg92qZsysYHMH7bRL7H6eDVwNSx',
      '9d656610ec7ff8a8e7e9225234ee54b6fa31d147981e1b91106ce901ae69bf00',
      'init', '["11","22","333"]');
    response := Piri_id.listTransactions();
    response := Piri_id.listPoolTransactions();
    response := Piri_id.listTransactionsByAssetID('-1', '0', '50');
    response := Piri_id.listTransactionsByAddr
      ('PRTMPUAV2mTGq6Dpu9ZBYmJyXWdt9RYiiouvRaZ8xUR', '0', '50');
    response := Piri_id.getTransaction
      ('f0f5733c7cc71ad3ae2dea4417c7e16a39aed9edba6a4c414568875b30a1ad9b');
    response := Piri_id.getPoolTransaction
      ('f0f5733c7cc71ad3ae2dea4417c7e16a39aed9edba6a4c414568875b30a1ad9b');
    response := Piri_id.getBlocks();
    response := Piri_id.getBlocksDesc();
    response := Piri_id.getLastBlocks();
    response := Piri_id.getOnlyBlocks();
    response := Piri_id.getBlock('2673310');
    response := Piri_id.pushData('PRTMRWG479eCmbbufg92qZsysYHMH7bRL7H6eDVwNSx',
      '9d656610ec7ff8a8e7e9225234ee54b6fa31d147981e1b91106ce901ae69bf00',
      'PRTMRN71Mz5mrZMA59mPtURrTG9S4yydYDyi1YNi5uX',
      ' { "key" : "somekey", "value" : "somevalue", "enc": 0}',
      '043e6ace02e5b6c8031455d91ae88b411b80935f48404c6014075043e71d2ffb8da3b2f5f3a480f9be45b9455b846781bdbdf6466076645cc86e5a00c82c51bc00');

    response := Piri_id.pushDataList
      ('PRTMRWG479eCmbbufg92qZsysYHMH7bRL7H6eDVwNSx',
      '9d656610ec7ff8a8e7e9225234ee54b6fa31d147981e1b91106ce901ae69bf00',
      'PRTMRN71Mz5mrZMA59mPtURrTG9S4yydYDyi1YNi5uX',
      ' { "key" : "somekey", "value" : "somevalue", "enc": 0}');
    response := Piri_id.listData();
    response := Piri_id.listDataByAddress
      ('PRTMRN71Mz5mrZMA59mPtURrTG9S4yydYDyi1YNi5uX');
    response := Piri_id.getAddressListByAsset();
    response := Piri_id.isValidAddress
      ('PRTMRN71Mz5mrZMA59mPtURrTG9S4yydYDyi1YNi5u0');
    response := Piri_id.search
      ('99f9f4ec7012db95868bb9526cd9b239765634183b64ad3eb7b3c13daf5ed12d');
    response := Piri_id.listDeputies();
    response := Piri_id.checkDeputy
      ('PRTMPRSg92ndyu5NeaEf7q3D6TdJeKKa6nKStVMcU4e');
    response := Piri_id.getMyRewardQuantity
      ('PRTMRWG479eCmbbufg92qZsysYHMH7bRL7H6eDVwNSx',
      '9d656610ec7ff8a8e7e9225234ee54b6fa31d147981e1b91106ce901ae69bf00');
    response := Piri_id.getPiriPrice();
    response := Piri_id.getRichList();
    response := Piri_id.getDetailStats();
    response := Piri_id.getStats();
    response := Piri_id.listDelegationTopN();
    response := Piri_id.getCirculation();
  finally
    if (Piri_id <> nil) then
      Piri_id.Free;

  end;
```

API documentation
------------

For more detailed and up-to-date API documentation, you can access it at https://api.pirichain.com and refer to the Postman collection documents specified at that address.

Changelog
------------

To keep track, please refer to [CHANGELOG.md](https://github.com/workmail20/Pirichain-api-csharp/blob/master/CHANGELOG.md).
