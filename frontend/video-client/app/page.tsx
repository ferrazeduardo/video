import Image from "next/image";
import Header from "./components/Header";
import { InformationCircleIcon } from "@heroicons/react/16/solid";
import { PlayIcon } from "@heroicons/react/16/solid";

export default function Home() {
  return (
    <div className="relative h-screen overflow-hidden bg-linear-to-b lg:h-[140vh]">
      <Header />
      <main className="relative pb-24 pl-4 lg:pl-16">
        <div className="flex flex-col space-y-2 py-16 md:space-y-4 lg:h-[65vh] lg:justify-end lg:pb-12">
          <div className="absolute flex flex-col left-0 top-0 -z-10 h-[95vh] w-screen bg-black">
            <Image
              src='/background.jpg'
              alt="background"
              fill={true}
              className="h-[65vh] object-cover object-top lg:h-[95vh]"
              />
          </div>

            <h1 className="text-2xl font-bold md:text-4xl lg:text-7xl">
              video
            </h1>

            <p className="text-shadow-md max-w-xs text-xs md:max-w-lg md:text-lg lg:max-w-2xl">
              ADEUS À CIDADE - "O Manchester City de repente se viu com seis zagueiros centrais em boa forma no verão, mas apenas dois puderam jogar. Quando não joguei no início da temporada, ponderei minhas opções com meu agente. Os clubes muitas vezes exigem lealdade dos seus jogadores, mas nem sempre a oferecem eles próprios. Portanto, às vezes os jogadores têm que tomar decisões egoístas que nem sempre são compreendidas por quem está fora do clube."
            </p>
        </div>
        <div className="flex space-x-3">
          <button className="md:text-xl flex cursor-pointer items-center gap-x-2 rounded bg-white  font-semibold text-black px-5 py-1.5  transition hover:opacity-15 md:px-8 md:py-2.5"><PlayIcon className="h-6"/> Play</button>
          <button className="md:text-xl flex cursor-pointer items-center gap-x-2 rounded bg-gray-300  font-semibold text-black px-5 py-1.5  transition hover:opacity-15 md:px-8 md:py-2.5"><InformationCircleIcon className="h-6" /> More Info</button>
        </div>
      </main>
    </div>
  );
}
