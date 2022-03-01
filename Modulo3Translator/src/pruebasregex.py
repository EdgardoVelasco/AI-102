import re

if __name__=="__main__":
    '''
    correo electrónico
    '''
    #regex=re.compile(r'[a-z,A-Z]{1}[a-z,\.,_,0-9,A-Z]+@[a-z]+\.com')
    '''
    numero de telefono
    '''
    regex=re.compile(r'[0-9]{2}[-,\,]?[0-9]{2}[-,\,]?[0-9]{2}[-,\,]?[0-9]{2}[-,\,]?[0-9]{2}')
    match=regex.fullmatch("55-85-73-74-asd")
    print("es correcta" if match!=None else "no hace match")