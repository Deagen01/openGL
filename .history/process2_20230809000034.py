# 导入re模块，用于正则表达式替换
import re
import sys
# 定义一个函数，接受一个cpp文件名作为参数
def replace_string(filename):
    # 打开文件，读取内容
    with open(filename, "r") as f:
        content = f.read()
        pos = content.find("#include <stb_image.h>")
        if pos!=-1:
            content = content[:pos-1] + "" +content[pos+len("#include <stb_image.h>")]
    # content4 = re.sub("learnopengl/","",content3)
    # 打开文件，写入新的内容
    with open(filename, "w") as f:
        f.write(content3)
    # 打印提示信息
    print(f"Successfully replaced {filename}!")

# 调用函数，传入要修改的cpp文件名
# read args from command line
def main():
    if len(sys.argv) >= 2:
        for i in range(1,len(sys.argv)):
            replace_string(sys.argv[i])
    else:
        print("please input filename")
# replace_string("example.cpp")

if __name__ == "__main__":
    main()
