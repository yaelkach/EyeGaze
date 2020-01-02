import PIL
from PIL import Image
import pytesseract
file_name = 'test1.png'


def extract_tsv_from_jpg():
    pytesseract.pytesseract.tesseract_cmd = r'C:\Program Files\Tesseract-OCR\tesseract.exe'
    tsvFile = open('data.tsv', 'w')
    tsvData = pytesseract.image_to_data(Image.open(file_name))
    tsvFile.write(tsvData)
    return tsvData

def main():
    text = extract_tsv_from_jpg()
