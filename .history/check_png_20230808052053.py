from PIL import Image
import sys

def main():
    if len(sys.argv) >= 2:
        for i in range(1,len(sys.argv)):
            img = Image.open(sys.argv[i])
            print(len(img.split()))
    else:
        print("please input filename")

if __name__ == "__main__":
    main()
