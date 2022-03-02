import http.client, json

host = "qnamakerenvf.azurewebsites.net"  
endpoint_key = "e0276009-5318-49fb-981a-7b78448c9529"
route = "/qnamaker/knowledgebases/6e617c8a-95a1-45ec-84af-c705ae13d476/generateAnswer"
headers = {
    'Authorization': 'EndpointKey ' + endpoint_key,
    'Content-Type': 'application/json'
  }

if __name__=="__main__":
  conn = http.client.HTTPSConnection(host,port=443)
  question = "{'question': 'cognitive services'}"
  conn.request ("POST", route,  question, headers)
  response = conn.getresponse ()
  answer = response.read ()
  print(json.dumps(json.loads(answer), indent=4))