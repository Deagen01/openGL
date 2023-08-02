# 导入re模块，用于正则表达式替换
import re

# 定义一个函数，接受一个cpp文件名作为参数
def replace_string(filename):
    # 打开文件，读取内容
    with open(filename, "r") as f:
        content = f.read()
    # 使用re.sub函数，将"GLADloadproc"替换成"GLADloadfunc"
    content1 = re.sub("GLADloadproc", "GLADloadfunc", content)
    content2 = re.sub("GLADloadproc", "GLADloadfunc", content1)
    # 打开文件，写入新的内容
    with open(filename, "w") as f:
        f.write(new_content)
    # 打印提示信息
    print(f"已经将{filename}中的'GLADloadproc'替换成'GLADloadfunc'")

# 调用函数，传入要修改的cpp文件名
replace_string("example.cpp")
