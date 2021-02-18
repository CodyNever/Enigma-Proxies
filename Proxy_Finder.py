import random

import requests
import re
from bs4 import BeautifulSoup

TIMEOUT = 0.25
MAX_PROXIES = 1000
working_proxy = []


def start_checking(count):
    proxies = grab_proxy()
    total_proxies_checked = 0

    # for proxy in proxies:
    #     total_proxies_checked += 1
    #     print(f'Проверка прокси {total_proxies_checked} из {len(proxies)}')
    #
    #     if check_proxy(proxy):
    #         working_proxy.append(proxy)
    #
    #     if len(working_proxy) >= count:
    #         return working_proxy
    #
    # if len(working_proxy) != 0:
    #     return working_proxy
    # else:
    #     print('ERROR: Не найдено прокси')

    global working_proxy
    working_proxy = []

    x = random.randint(0, len(proxies))
    start_pos = x

    while True:
        if x > len(proxies) - 2:
            x = 0
        x += 1

        if x == start_pos:
            print('ERROR: Не найдено прокси')
            return

        print(f'Проверка прокси {x} из {len(proxies)}')

        if check_proxy(proxies[x]):
            working_proxy.append(proxies[x])

        if len(working_proxy) >= count:
            return working_proxy


def grab_proxy():
    proxies = []
    html = requests.get('https://free-proxy-list.net')
    soup = str(BeautifulSoup(html.text, 'html.parser')).split()

    ip_like_pattern = re.compile(r'([0-9]{1,3}\.){3}([0-9]{1,3})')

    for entry in soup:
        if re.match(ip_like_pattern, entry):
            if len(entry.split('.')) == 4:
                proxies.append(entry)
    return proxies
    # return proxies[MAX_PROXIES]


def check_proxy(proxy):
    url = 'http://' + proxy
    try:
        if requests.get('http://ya.ru', proxies={'http': url}, timeout=TIMEOUT).status_code == 200:
            return True
    except Exception:
        return False
