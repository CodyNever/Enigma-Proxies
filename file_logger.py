from datetime import datetime

open('log.txt', 'w').close()


def log(printing):
    log_file = open("log.txt", "a")
    log_file.write(str(datetime.now()) + ' ' + str(printing) + '\n')
    print(f'{str(datetime.now())} {str(printing)}')
    log_file.close()
    # return printer
