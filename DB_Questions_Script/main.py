import requests

x = requests.get('https://w3schools.com/python/demopage.htm')

print(x.text)

def main():
    response = requests.get(api_url)

    # Check if the request was successful (status code 200)
    if response.status_code == 200:
        # Print the response content
        print(response.content.decode('utf-8'))
    else:
        print('Error occurred:', response.status_code)


# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    main()

# See PyCharm help at https://www.jetbrains.com/help/pycharm/
