
import React from "react";

export default function Header() {
    return (
        <header
            className="
            fixed
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
            lg:py-6"

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
                <img  src='/usuario.jpg' className="cursor-pointer rounded"/>
                <button className="flex items-center space-x-2 bg-white py-2 px-4 rounded text-black text-sm font-semibold">test</button>
                <button className="flex items-center space-x-2 bg-white py-2 px-4 rounded text-black text-sm font-semibold">test</button>
            </div>
        </header>
    )

}