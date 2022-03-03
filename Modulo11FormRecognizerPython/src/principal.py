from azure.core.credentials import AzureKeyCredential
from azure.ai.formrecognizer import DocumentAnalysisClient
'''
Para usar form Recognizer se necesita la siguiente informacion:
>ENDPOINT
>APIKEY
>MODELID
'''
ENDPOINT="https://cognitivenvfne.cognitiveservices.azure.com/"
APIKEY="02efc28c161949efb8872cb5aef84120"
MODELID="analisisfacturas"

if __name__=="__main__":
    print("FormRecognizer".center(30, "▼"))
    #Conexion a form recognizer
    conexion=DocumentAnalysisClient(endpoint=ENDPOINT,
                                    credential=AzureKeyCredential(APIKEY))
    urlArchivo=input("Escribe url: ")
    
    #ejecutando form recognizer
    resultado=conexion.begin_analyze_document_from_url(MODELID, urlArchivo)
    datos=resultado.result()
    #print(datos.documents)
    #imprimir resultados
    print("Información obtenida de form recognizer".center(50,"§"))
    for datos, documentos in enumerate(datos.documents):
        print("Documento".center(25,"+"))
        for nombre, field in documentos.fields.items():
            valor=field.value if field.value else field.content
            print("dato encontrado en archivo: {} confidence score {}".format(valor, field.confidence))
            
    
    
    
    

