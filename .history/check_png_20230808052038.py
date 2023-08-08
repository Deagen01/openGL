from PIL import Image
import sys


img = Image.open('img1.png')
print(len(img.split()))
if __name__ == "__main__":
    main()
