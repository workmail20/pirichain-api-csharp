using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace pirichain_api_workmail20
{
    public class PirichainAPI_w20
    {
        private string mainEndpoit = "https://core.pirichain.com/";
        private string testEndpoit = "https://testnet.pirichain.com/";
        private string endpoint = "";
        private HttpClient client;

        public PirichainAPI_w20(bool main)
        {
            if (main)
            {
                endpoint = mainEndpoit;
            }
            else
            {
                endpoint = testEndpoit;
            }

            client = createHTTPClient();
        }

        public HttpClient createHTTPClient()
        {
            var _client = new HttpClient(new HttpClientHandler
            {
                MaxConnectionsPerServer = 10
            });
            _client.Timeout = TimeSpan.FromSeconds(60);
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.63 Safari/537.36 Edg/93.0.961.47");
            return _client;
        }

        public async Task<string> sendHttpPOST_json(string url, string data = "")
        {
            string Result = "";
            var cts = new CancellationTokenSource();


            try
            {

                var content = new StringContent(data, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var orgResponse = await client.PostAsync(url, content, cts.Token);
                if (orgResponse.IsSuccessStatusCode)
                {
                    Result = await orgResponse.Content.ReadAsStringAsync();
                }
            }
            catch (WebException)
            {
                Result = "";
            }
            catch (TaskCanceledException ex)
            {
                if (ex.CancellationToken == cts.Token)
                {
                    Result = "";
                }
                else
                {
                    Result = "";
                }
            }

            if (Result == "")
            {
                client.Dispose();
                client = createHTTPClient();
            }
            return Result;
        }

        public async Task<string> createNewAddress(string language = "english", bool commercial = false)
        {

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("language", language);
            data.Add("isCommercial", commercial.ToString());

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "createNewAddress", json);
        }


        public async Task<string> rescuePrivateKey(string words, string language = "english")
        {
            if (words.Length < 8) throw new Exception("Error");
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("words", words);
            data.Add("language", language);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "rescuePrivateKey", json);
        }

        public async Task<string> getMnemonic(string privateKey, string language = "english")
        {
            if (privateKey.Length < 8) throw new Exception("Error");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("privateKey", privateKey);
            data.Add("language", language);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getMnemonic", json);
        }

        public async Task<string> getBalance(string address, string assetID = "-1")
        {
            if (address.Length < 8) throw new Exception("Error");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("address", address);
            data.Add("assetID", assetID);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getBalance", json);
        }

        public async Task<string> getBalanceList(string address)
        {
            if (address.Length < 8) throw new Exception("Error");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("address", address);


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getBalanceList", json);
        }


        //Token
        public async Task<string> getToken(string assetID = "-1")
        {

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("assetID", assetID);


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getToken", json);
        }

        public async Task<string> listTokens(string skip = "0", string limit = "10")
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("skip", skip);
            data.Add("limit", limit);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "listTokens", json);
        }

        public async Task<string> sendToken(string address, string privateKey, string to, string amount, string assetID = "-1")
        {
            if ((address.Length < 8) || (privateKey.Length < 8) || (to.Length < 8)) throw new Exception("Error");


            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("address", address);
            data.Add("privateKey", privateKey);
            data.Add("to", to);
            data.Add("amount", amount);
            data.Add("assetID", assetID);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "sendToken", json);
        }

        public async Task<string> createToken(
            string creatorAddress,
            string privateKey,
            string tokenName,
            string tokenSymbol,
            string totalSupply,
            string logo,
            string decimals,
            string description,
            string webSite,
            string socialMediaFacebookURL,
            string socialMediaTwitterURL,
            string socialMediaMediumURL,
            string socialMediaYoutubeURL,
            string socialMediaRedditURL,
            string socialMediaBitcoinTalkURL,
            string socialMediaInstagramURL,
            string mailAddress,
            string companyAddress,
            string sector,
            bool hasAirdrop,
            bool hasStake)
        {

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("creatorAddress", creatorAddress);
            data.Add("privateKey", privateKey);
            data.Add("tokenName", tokenName);
            data.Add("tokenSymbol", tokenSymbol);
            data.Add("totalSupply", totalSupply);
            data.Add("logo", logo);
            data.Add("decimals", decimals);
            data.Add("description", description);
            data.Add("webSite", webSite);
            data.Add("socialMediaFacebookURL", socialMediaFacebookURL);
            data.Add("socialMediaTwitterURL", socialMediaTwitterURL);
            data.Add("socialMediaMediumURL", socialMediaMediumURL);
            data.Add("socialMediaYoutubeURL", socialMediaYoutubeURL);
            data.Add("socialMediaRedditURL", socialMediaRedditURL);
            data.Add("socialMediaBitcoinTalkURL", socialMediaBitcoinTalkURL);
            data.Add("socialMediaInstagramURL", socialMediaInstagramURL);
            data.Add("mailAddress", mailAddress);
            data.Add("companyAddress", companyAddress);
            data.Add("sector", sector);
            data.Add("hasAirdrop", hasAirdrop.ToString());
            data.Add("hasStake", hasStake.ToString());

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "createToken", json);

        }

        //Scenario
        public async Task<string> getScenario(string address)
        {
            if (address.Length < 8) throw new Exception("Error");


            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("address", address);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getScenario", json);
        }

        public async Task<string> createScenario(string address, string privateKey, string scenarioText, string name, string description, string tags)
        {
            if (address.Length < 8) throw new Exception("Error");


            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("address", address);
            data.Add("privateKey", privateKey);
            data.Add("scenarioText", scenarioText);
            data.Add("name", name);
            data.Add("description", description);
            data.Add("tags", tags);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "createScenario", json);
        }

        public async Task<string> listMyScenarios(string ownerAddress)
        {
            if (ownerAddress.Length < 8) throw new Exception("Error");


            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("ownerAddress", ownerAddress);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "listMyScenarios", json);

        }

        public async Task<string> listScenarios(string skip = "0", string limit = "10")
        {


            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("skip", skip);
            data.Add("limit", limit);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "listScenarios", json);
        }

        public async Task<string> executeScenario(string scenarioAddress, string address, string privateKey, string method, string _params)
        {
            if (scenarioAddress.Length < 8) throw new Exception("Error");
            //$params = ["Data1", "Data2"]

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("scenarioAddress", scenarioAddress);
            data.Add("address", address);
            data.Add("privateKey", privateKey);
            data.Add("method", method);
            data.Add("params", _params);


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "executeScenario", json);
        }


        public async Task<string> previewScenario(string scenarioText, string address, string privateKey, string method, string _params)
        {


            //$params = ["Data1", "Data2"]
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("scenarioText", scenarioText);
            data.Add("address", address);
            data.Add("privateKey", privateKey);
            data.Add("method", method);

            data.Add("params", _params);


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "previewScenario", json);
        }


        public async Task<string> listTransactions(string skip = "0", string limit = "50")
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("skip", skip);
            data.Add("limit", limit);


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "listTransactions", json);
        }

        public async Task<string> listPoolTransactions()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "listPoolTransactions", json);
        }

        public async Task<string> listTransactionsByAssetID(string skip = "0", string limit = "10", string assetID = "-1")
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("skip", skip);
            data.Add("limit", limit);
            data.Add("assetID", assetID);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "listTransactionsByAssetID", json);
        }

        public async Task<string> listTransactionsByAddr(string address, string skip = "0", string limit = "10")
        {
            if (address.Length < 8) throw new Exception("Error");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("skip", skip);
            data.Add("limit", limit);
            data.Add("address", address);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "listTransactionsByAddr", json);
        }

        public async Task<string> getTransaction(string tx)
        {
            if (tx.Length < 8) throw new Exception("Error");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("tx", tx);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getTransaction", json);
        }

        public async Task<string> getPoolTransaction(string tx)
        {
            if (tx.Length < 8) throw new Exception("Error");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("tx", tx);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getPoolTransaction", json);
        }

        public async Task<string> getDetailsOfAddress(string address)
        {
            if (address.Length < 8) throw new Exception("Error");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("address", address);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getDetailsOfAddress", json);
        }

        //block
        public async Task<string> getBlocks(string skip = "0", string limit = "10")
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("skip", skip);
            data.Add("limit", limit);


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getBlocks", json);
        }

        public async Task<string> getBlocksDesc(string skip = "0", string limit = "10")
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("skip", skip);
            data.Add("limit", limit);


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getBlocksDesc", json);
        }

        public async Task<string> getLastBlocks(string limit = "10")
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("limit", limit);


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getLastBlocks", json);
        }

        public async Task<string> getOnlyBlocks(string skip = "0", string limit = "10")
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("skip", skip);
            data.Add("limit", limit);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getOnlyBlocks", json);

        }

        public async Task<string> getBlock(string blockNumber)
        {
            if (blockNumber.Length < 1) throw new Exception("Error");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("blockNumber", blockNumber);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getBlock", json);

        }

        //data
        public async Task<string> decrypt(string customID, string privateKey, string receiptPub)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("customID", customID);
            data.Add("privateKey", privateKey);
            data.Add("receiptPub", receiptPub);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "decrypt", json);
        }

        public async Task<string> pushData(string address, string privateKey, string to, string customData, string inPubKey)
        {
            if (address.Length < 8) throw new Exception("Error");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("address", address);
            data.Add("privateKey", privateKey);
            data.Add("to", to);
            data.Add("customData", customData);
            data.Add("inPubKey", inPubKey);


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "pushData", json);
        }


        public async Task<string> pushDataList(string address, string privateKey, string to, string customData)
        {
            if (address.Length < 8) throw new Exception("Error");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("address", address);
            data.Add("privateKey", privateKey);
            data.Add("to", to);
            data.Add("customData", customData);


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "pushDataList", json);
        }

        public async Task<string> listData(string skip = "0", string limit = "10")
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("skip", skip);
            data.Add("limit", limit);


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "listData", json);
        }

        public async Task<string> listDataByAddress(string address, string skip = "0", string limit = "10")
        {
            if (address.Length < 8) throw new Exception("Error");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("address", address);
            data.Add("skip", skip);
            data.Add("limit", limit);


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "listDataByAddress", json);
        }

        public async Task<string> getAddressListByAsset(string assetID = "-1", string start = "0", string limit = "10")
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("assetID", assetID);
            data.Add("start", start);
            data.Add("limit", limit);


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getAddressListByAsset", json);
        }
        // /Utility
        public async Task<string> isValidAddress(string address)
        {
            if (address.Length < 8) throw new Exception("Error");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("address", address);


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "isValidAddress", json);
        }

        public async Task<string> search(string value)
        {
            if (value.Length < 1) throw new Exception("Error");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("value", value);


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "search", json);
        }

        //Delegation
        public async Task<string> listMyDelegation(string delegationAddress, string delegationPrivateKey)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("delegationAddress", delegationAddress);
            data.Add("delegationPrivateKey", delegationPrivateKey);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "listMyDelegation", json);
        }
        public async Task<string> unFreezeCoin(string delegationAddress, string delegationPrivateKey, string nodeAddress, string txHash)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("delegationAddress", delegationAddress);
            data.Add("delegationPrivateKey", delegationPrivateKey);
            data.Add("nodeAddress", nodeAddress);
            data.Add("txHash", txHash);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "unFreezeCoin", json);
        }

        public async Task<string> freezeCoin(string delegationAddress, string delegationPrivateKey, string duptyAddress, string amount)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("delegationAddress", delegationAddress);
            data.Add("delegationPrivateKey", delegationPrivateKey);
            data.Add("duptyAddress", duptyAddress);
            data.Add("amount", amount);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "freezeCoin", json);
        }

        public async Task<string> joinAsDeputy(string address, string privateKey, string alias)
        {
            if (address.Length < 8) throw new Exception("Error");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("address", address);
            data.Add("privateKey", privateKey);
            data.Add("alias", alias);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "joinAsDeputy", json);
        }

        public async Task<string> checkDeputy(string address)
        {
            if (address.Length < 8) throw new Exception("Error");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("address", address);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "checkDeputy", json);
        }


        public async Task<string> listDeputies()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "listDeputies", json);
        }

        public async Task<string> getMyRewardQuantity(string base58, string privateKey)
        {
            if (base58.Length < 8) throw new Exception("Error");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("base58", base58);
            data.Add("privateKey", privateKey);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getMyRewardQuantity", json);
        }

        public async Task<string> createAddressForBuyPiri(string type)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("type", type);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "createAddressForBuyPiri", json);
        }

        public async Task<string> getBalanceForBuyPiri(string type, string address, string piriAddress)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("type", type);
            data.Add("address", address);
            data.Add("piriAddress", piriAddress);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getBalanceForBuyPiri", json);
        }

        public async Task<string> getPiriPrice(string type = "busd")
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("type", type);

            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getPiriPrice", json);
        }

        //Stats
        public async Task<string> getRichList(string assetID = "-1", string skip = "0", string limit = "10")
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("assetID", assetID);
            data.Add("skip", skip);

            data.Add("limit", limit);


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getRichList", json);
        }

        public async Task<string> getDetailStats(string assetID = "-1")
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("assetID", assetID);


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getDetailStats", json);
        }

        public async Task<string> getStats()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getStats", json);
        }

        public async Task<string> listDelegationTopN()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "listDelegationTopN", json);
        }

        public async Task<string> getCirculation()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();


            var json = JsonConvert.SerializeObject(data);
            return await sendHttpPOST_json(endpoint + "getCirculation", json);
        }
    }
}