#!/usr/bin/env python

import numpy as np
import cv2


def inside(r, q):
    rx, ry, rw, rh = r
    qx, qy, qw, qh = q
    return rx > qx and ry > qy and rx + rw < qx + qw and ry + rh < qy + qh

def draw_detections(img, rects, thickness = 1):
    for x, y, w, h in rects:
        # the HOG detector returns slightly larger rectangles than the real objects.
        # so we slightly shrink the rectangles to get a nicer output.
        pad_w, pad_h = int(0.15*w), int(0.05*h)
        cv2.rectangle(img, (x+pad_w, y+pad_h), (x+w-pad_w, y+h-pad_h), (0, 255, 0), thickness)

def espera_tocar(canal):
    while canal.get_busy():
        pass


if __name__ == '__main__':
    import sys
    from glob import glob
    import itertools as it

    import glob as globDir
    import time
    #import serial
    import os.path
    import pygame.mixer

    #ser = serial.Serial('COM5')
    sounds = pygame.mixer


    hog = cv2.HOGDescriptor()
    hog.setSVMDetector( cv2.HOGDescriptor_getDefaultPeopleDetector() )

    n=0
    while True:
        try:
            nameImg = str(n)  + ".bmp"
            nameNextImg = str(n+1) + ".bmp"
            if(os.path.exists(nameNextImg)):
                img = cv2.imread(nameImg)
                n=n+1
                found, w = hog.detectMultiScale(img, winStride=(8,8), padding=(32,32), scale=1.05)
                found_filtered = []
                for ri, r in enumerate(found):
                    for qi, q in enumerate(found):    
                        if ri != qi and inside(r, q):
                            break
                        else:
                            found_filtered.append(r)
                draw_detections(img,found)
                draw_detections(img,found_filtered,3)
                if(len(found)>0):
                    print '%s - %d pessoas encontradas!!!!!!!!' % (nameImg,len(found))
                    #ser.write('t')
                    sounds.init()
                    s = sounds.Sound("alarme.wav")
                    espera_tocar(s.play())
                else:
                    print '%s - Nao encontrou pessoas' % (nameImg)
            continue
        except:
            continue    


    
