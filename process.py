# process.py预处理文件

# 在#include <stb_image.h>之前加入

# #define STB_IMAGE_IMPLEMENTATION

# 以及

# ```

# #include <glad/gl.h>

# GLADloadproc->GLADloadfunc

# gladLoadGLLoader->gladLoadGL

# GLFW_CURSOR_DISABLED->GLFW_CURSOR_NORMAL

# ```
import re
import sys

def add_string(filename):
    # 打开文件，读取内容
    add1 = "#define STB_IMAGE_IMPLEMENTATION"
    with open(filename, "r") as f:
        content = f.read()
        pos = content.find("#include <stb_image.h>")
        if pos!=-1:
            content = content[:pos-1] + "\n"+add1+"\n" +content[pos:]
    # content4 = re.sub("learnopengl/","",content3)
    # 打开文件，写入新的内容
    with open(filename, "w") as f:
        f.write(content)
    # 打印提示信息
    print(f"Successfully replaced {filename}!")

def replace_string(filename):
    # 打开文件，读取内容
    with open(filename, "r") as f:
        content = f.read()
    # 使用re.sub函数，将"GLADloadproc"替换成"GLADloadfunc"
    content1 = re.sub("GLADloadproc", "GLADloadfunc", content)
    content2 = re.sub("gladLoadGLLoader", "gladLoadGL", content1)
    content3 = re.sub("<glad/glad.h>","<glad/gl.h>",content2)
    content4 = re.sub("GLFW_CURSOR_DISABLED","GLFW_CURSOR_NORMAL",content3)
    
    # content4 = re.sub("learnopengl/","",content3)
    # 打开文件，写入新的内容
    with open(filename, "w") as f:
        f.write(content4)
    # 打印提示信息
    print(f"Successfully add to {filename}!")

# 调用函数，传入要修改的cpp文件名
# read args from command line
def main():
    if len(sys.argv) >= 2:
        for i in range(1,len(sys.argv)):
            replace_string(sys.argv[i])
            add_string(sys.argv[i])
    else:
        print("please input filename")
# replace_string("example.cpp")

if __name__ == "__main__":
    main()
