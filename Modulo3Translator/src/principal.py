import requests, uuid, json

#APIKEY, LOCATION, URL
api_key="9fa7d48f174646299522f39e48d5dd09"
location="eastus"
url="https://api.cognitive.microsofttranslator.com/"

if __name__=="__main__":
    print("Translator".center(30, "+"))
    path="/translate"
    url_completo=url+path
    parametros={
        'api-version':'3.0',
        'from':'es',
        'to':['fr', 'en']
    }
    headers={
        'Ocp-Apim-Subscription-Key':api_key,
        'Ocp-Apim-Subscription-Region':location,
        'Content-type':'application/json',
        'X-ClientTraceId':str(uuid.uuid4())
    }
    body=[{
        'text':input("Escribe texto: ")
    }]
    
    respuesta=requests.post(url_completo, 
                            params=parametros, 
                            headers=headers,
                            json=body)
    datos=respuesta.json()
    
    print(json.dumps(datos, sort_keys=True, ensure_ascii=False, indent=3, separators=(',', ': ' )))
    
    
    
    
    