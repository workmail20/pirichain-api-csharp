# Pirichain-api-csharp

Package for Pirichain API calls through C-sharp
============
![Nuget](https://img.shields.io/nuget/dt/workmail20.pirichain.api)    ![Nuget](https://img.shields.io/nuget/v/workmail20.pirichain.api)    ![Static Badge](https://img.shields.io/badge/.NET_Framework-4.8.0-yellowgreen)    ![Static Badge](https://img.shields.io/badge/.NET-6.0-yellowgreen)    ![GitHub](https://img.shields.io/github/license/workmail20/pirichain-api-php)





---
Pirichain is blockchain system that based on dPos (Delegated Proof of Stake) and has it own environment to create wallet and token, transactions, sending or storing data as a transaction, delegation.


Requirements
------------

* .NET >= 6.0;
* .NET Framework >= 4.8.0;

Installation
------------

    dotnet add package workmail20.pirichain.api --version 1.0.2
or

    NuGet\Install-Package workmail20.pirichain.api -Version 1.0.2

NuGet Package
------------

https://www.nuget.org/packages/workmail20.pirichain.api

Usage
------------
```csharp
PirichainAPI_w20 papi = new PirichainAPI_w20(true);

string response = "";
response = await papi.createNewAddress();
response = await papi.createNewAddress("portuguese", true);
response = await papi.rescuePrivateKey("entry frequent airport firm document close human roof fix pond popular laugh banner fruit faint exact sleep axis pipe crush today elder inform saddle");
response = await papi.getMnemonic("4bab94162ba406575bb5dd5814faa0bec124bb947a72cb221e951a8e348e9ce5");
response = await papi.getBalance("PRTMRWG479eCmbbufg92qZsysYHMH7bRL7H6eDVwNSx");
response = await papi.getBalanceList("PRTMRgoFporAfQYrNNJfj3Go37FT5AR3ueKCwpdKd1s");
response = await papi.getToken();
response = await papi.listTokens();
response = await papi.getScenario("PRTMQ7fcZp7ACGDEom4KJQ4bvJ5nwQ3CcaUTFy642mE");
response = await papi.listMyScenarios("PRTMPUAV2mTGq6Dpu9ZBYmJyXWdt9RYiiouvRaZ8xUR");
response = await papi.listScenarios();
response = await papi.executeScenario("PRTMPBjj3sutTtHwvRgB8YFHtMdcTv1Bd7cMWMxMrZP", "PRTMRWG479eCmbbufg92qZsysYHMH7bRL7H6eDVwNSx",
"9d656610ec7ff8a8e7e9225234ee54b6fa31d147981e1b91106ce901ae69bf9b", "init", "[\"11\",\"22\",\"333\"]");
response = await papi.previewScenario("{}", "PRTMRWG479eCmbbufg92qZsysYHMH7bRL7H6eDVwNSx",
"9d656610ec7ff8a8e7e9225234ee54b6fa31d147981e1b91106ce901ae69bf9b", "init", "['11','22','333']");
response = await papi.listTransactions();
response = await papi.listPoolTransactions();
response = await papi.listTransactionsByAssetID("0", "50", "-1");
response = await papi.listTransactionsByAddr("PRTMPUAV2mTGq6Dpu9ZBYmJyXWdt9RYiiouvRaZ8xUR", "0", "50");
response = await papi.getTransaction("f0f5733c7cc71ad3ae2dea4417c7e16a39aed9edba6a4c414568875b30a1ad9b");
response = await papi.getPoolTransaction("f0f5733c7cc71ad3ae2dea4417c7e16a39aed9edba6a4c414568875b30a1ad9b");
response = await papi.getBlocks();
response = await papi.getBlocksDesc();
response = await papi.getLastBlocks();
response = await papi.getOnlyBlocks();
response = await papi.getBlock("2673310");
response = await papi.createToken("","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", true, false);
response = await papi.pushData("PRTMRWG479eCmbbufg92qZsysYHMH7bRL7H6eDVwNSx", "9d656610ec7ff8a8e7e9225234ee54b6fa31d147981e1b91106ce901ae69bf9b", "PRTMRN71Mz5mrZMA59mPtURrTG9S4yydYDyi1YNi5uX",
"{\"key\":\"xxxx1\",\"value\":\"xxxxx\",\"enc\":\"1\"}",
"043e6ace02e5b6c8031455d91ae88b411b80935f48404c6014075043e71d2ffb8da3b2f5f3a480f9be45b9455b846781bdbdf6466076645cc86e5a00c82c51bc00");
response = await papi.listData();
response = await papi.listDataByAddress("PRTMRN71Mz5mrZMA59mPtURrTG9S4yydYDyi1YNi5uX");
response = await papi.getAddressListByAsset();
response = await papi.isValidAddress("PRTMRN71Mz5mrZMA59mPtURrTG9S4yydYDyi1YNi5u0");
response = await papi.search("99f9f4ec7012db95868bb9526cd9b239765634183b64ad3eb7b3c13daf5ed12d");
response = await papi.search("2673310");
response = await papi.listDeputies();
response = await papi.checkDeputy("PRTMPRSg92ndyu5NeaEf7q3D6TdJeKKa6nKStVMcU4e");
response = await papi.getMyRewardQuantity("PRTMRWG479eCmbbufg92qZsysYHMH7bRL7H6eDVwNSx", "9d656610ec7ff8a8e7e9225234ee54b6fa31d147981e1b91106ce901ae69bf9b");
response = await papi.getPiriPrice();
response = await papi.getRichList();
response = await papi.getDetailStats();
response = await papi.getStats();
response = await papi.listDelegationTopN();
response = await papi.getCirculation();
```

API documentation
------------

For more detailed and up-to-date API documentation, you can access it at https://api.pirichain.com and refer to the Postman collection documents specified at that address.

Changelog
------------

To keep track, please refer to [CHANGELOG.md](https://github.com/workmail20/Pirichain-api-csharp/blob/master/CHANGELOG.md).
