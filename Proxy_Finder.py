from datetime import datetime
from bs4 import BeautifulSoup
from enum import Enum
import requests
import random
import re

TIMEOUT = 0.6
MAX_PROXIES = 1000

FINDER_TYPE = Enum('FinderType', 'site file')
MY_TYPE = FINDER_TYPE.file

working_proxy = []


def start_checking(count):
    proxies = grab_proxy()

    global working_proxy
    working_proxy = []

    x = random.randint(0, len(proxies))
    start_pos = x

    print(f'[ Start finding proxies {datetime.now()} ]')
    while True:
        if x > len(proxies) - 2:
            x = 0
        x += 1

        if x == start_pos:
            return

        # print(f'{x} / {len(proxies)}')

        if check_proxy(proxies[x]):
            working_proxy.append(proxies[x])

        if len(working_proxy) >= count:
            return working_proxy


def grab_proxy():
    proxies = []
    ip_like_pattern = re.compile(r'([0-9]{1,3}\.){3}([0-9]{1,3})')

    soup = open('proxies.txt').read().split('\n')

    if soup is None:
        MY_TYPE == FINDER_TYPE.site

    if MY_TYPE == FINDER_TYPE.site:
        html = requests.get('https://free-proxy-list.net')
        soup = str(BeautifulSoup(html.text, 'html.parser')).split()

    for entry in soup:
        if re.match(ip_like_pattern, entry):
            if len(entry.split('.')) == 4:
                proxies.append(entry)
    return proxies


def check_proxy(proxy):
    url = 'http://' + proxy
    try:
        if requests.get('http://ya.ru', proxies={'http': url}, timeout=TIMEOUT).status_code == 200:
            return True
    except Exception:
        return False
