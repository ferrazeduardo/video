
"use client";  
import React, { useEffect, useState } from "react";

export default function Header() {
    const [isScrolled, setIsScrolled] = useState(false);

    useEffect(() => {
        const handleSchroll = () => {
            if (window.scrollY > 0) {
                setIsScrolled(true)
            } else {
                setIsScrolled(false)
            }
        };
        window.addEventListener('scroll', handleSchroll);
        return () => window.removeEventListener('scroll', handleSchroll);
    }, [])

    return (
        <header
            className={`${isScrolled && 'bg-black'}  fixed
            top-0
            z-50
            flex
            w-full
            items-center
            justify-between
            px-4
            py-4
            transition-all
            lg:px-10 
            lg:py-6`}
           

        >
            <div className="flex items-center space-x-2 md:space-x-8">
                <ul className="hidden md:flex md:space-x-4">
                    <li>Home</li>
                    <li>TV Shows</li>
                    <li>Movies</li>
                    <li>Latest</li>
                </ul>
            </div>
            <div className="flex items-center space-x-4">
                <p className="hidden cursor-not-allowed lg:inline">Usuario</p>
                <button className="flex items-center space-x-2 bg-white py-2 px-4 rounded text-black text-sm font-semibold">test</button>
                <button className="flex items-center space-x-2 bg-white py-2 px-4 rounded text-black text-sm font-semibold">test</button>
                <img src='/usuario.jpg' className="cursor-pointer rounded" />
            </div>
        </header>
    )

}