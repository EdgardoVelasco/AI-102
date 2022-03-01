import re

if __name__=="__main__":
    regex=re.compile(r'.*[\.jpg,\.png]$')
    match=regex.fullmatch("imagen1.exe")
    print("es correcta" if match!=None else "no hace match")