// <auto-generated />
namespace Lbk.MobileApp.Data.SqlCe.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    
    public sealed partial class AddEventThumbnailNameColumn : IMigrationMetadata
    {
        string IMigrationMetadata.Id
        {
            get { return "201205040959335_AddEventThumbnailNameColumn"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return "H4sIAAAAAAAEAOy9B2AcSZYlJi9tynt/SvVK1+B0oQiAYBMk2JBAEOzBiM3mkuwdaUcjKasqgcplVmVdZhZAzO2dvPfee++999577733ujudTif33/8/XGZkAWz2zkrayZ4hgKrIHz9+fB8/Iv7Hv/cffPx7vFuU6WVeN0W1/Oyj3fHOR2m+nFazYnnx2Ufr9nz74KPf4+g3Th6fzhbv0p807fbQjt5cNp99NG/b1aO7d5vpPF9kzXhRTOuqqc7b8bRa3M1m1d29nZ2Du7s7d3MC8RHBStPHr9bLtljk/Af9eVItp/mqXWflF9UsLxv9nL55zVDTF9kib1bZNP/so+eTt+MvqklR5ser1fhp1mbj17+oPMk/So/LIiN8Xufl+Xsit/MQyH1ku6WOTwnB9vrN9Srnzj/76HjZXOW134Za/V75dfABffSyrlZ53V6/ys/1zbPZR+nd8L273Rfta9476Jx+W7af7n+UvliXZTYp6YPzrGxotKtPH71uqzr/PF/mddbms5dZ2+b1Eu/mjLwS4dHq09vR4eHdnT3Q4W62XFZt1tJM9xDvoPk0b6Z1sZKmgu/rtibe+Sh9VrzLZ8/z5UU7tzh/kb0zn+zdv/9R+tWyIFajl9p6nftjlL839336blVmS0Xzh9z3WfOquJi3pt8nVVXm2TIyS5vB/MQ6b4D/zbPdgfMiuywueOgDED9KX+UlN2jmxUqEYiws/Pu7Ns/qavGqQjedr37/19W6nlK/b6r492+y+iJvQ7we33VCs1GULAI/Eqb/twjTi/ViQtrNkene3s1c2IHxsiqWbfNhMF7ndZHfPF+bgZzQDF5U9fV7wxkUK2H/5kOlykjNkFQZqbstWkytKFIOpDRxOIXf9AS983VMzjdhZEi/GSnXKoKX+XIYNdvig7SQUOZHKijg82lbXKLzY2vbyMPK35CvdrP0/L9InZFvUNR58w2M4qyxNHlva3+jlY4rlFvLbledDIj215IOA8uK6o8ExUfzTdGW+Xuy9SamjjDQrafqR1MURfPnUv98Hfb4Gr0OKphnVTWLKxdrO7WJUy7hNz3r2/n6g0wvQPyIW78Zn/X/RVz/Rb5cfyj+L+uCuU6sdj4tFln5Ufqypt80RXXwUfp6mgHg1wgvqrr9sp59aKTzcy3eG73sW0t4130YUAC3RQqzH0UI4H5/+dbhYj/sKRr3zQfpGO7wRzom0A3U8Qc7xD9UBfM1DNwN3NZl+j4ffi1uO72kWfz/GLv9bLPbNxpMeqz7s8dukU4Da/H10f9hCs3/K2PhDqhXeZPXl8xGz4vl2x86Ud7MKeG5zIry56b3H47/MDRm/Pmz3PutFefLYtqu6x/l4X62GeRWUvlzqaae0YruD4Ex+x3/nGiArxWI3FqofrKY5dXNIvXzSqT+f8fbt5Lob5y5b9Xr1+Lun1sjPSRbx01TTQvmMMWqk54PR3C6nKWb19lkEH6en/Bel22xKospIfDZR9/q0WUQqo1mHFRdNAhB7oZoEsgvl0/zMm/zFC4d8ionWTPNZv05IbrMwk9IXeQ15DYrTyj0auuM1n375rpYTotVVm5EvPPWLc08sLLwu988zVf5Empl4zzcpmO7Ft3v3XbSodVNpHl81+OnW7LZQHo/whP9ldNviNl6C64RwC4n9f9a1usO4zZM8E1xX3dubtO3nxP+OeHB42Vzlde/v+WdIUbptIvxnzR5H+7rAt3Ae//v47kB5G8z6x/IcQNzcZuezTs/Z/zmcndDTBFJGzt24GWl9+CwSFbQAZMU4v/b+KqH8m3m9QM5qkfz2/Rp1oJ+TvioswQyNP9DK56OCX4oRm0QoQhX3o7FvxZrxalxm7n+QP6Kj/o2Hf+QDaRECPROS2/kteH0akLh3fFq9XSCr/J33XUAee113gZWlVYvXMTRMZI9jRUCMHo6BsKZxBuAvIZ3G4OgAcQtcTBTsAkXJ0U3AN0E7NZAdGmoB0BE54aXobZiL4s1uOFlXgSKvS2rQze9rqnQGACTJb0JBCd+YgAkI9R93ePz/sxqfJt6jTrzGouAA302EANbrANW7gnwjVGvB+e1cnNX2YYjfJ/RO37bQIB4bBbHvRedfX0y9OKxCChPlj6YKN04IEKSjaFCMIqhYMEbg9WQG4gxFB7chqpfgwTesnJ/8AN+a4Bv33P1MFWdtWG4fV/Ve1211gcPsuM3RUa6ybMK8B3wrTykBxl0E5zI4KO02zB4k+mzdtx+9/jua0466weP71KTab5q11n5BaURy8Z88UW2WlES0vztPklfr7IpsN5+rSnt2+WzD+5SSnshMO5OA7p2vQ7bE2XUs4u88y11TZg+K+qmpWXebJIhLXoyW/Sa3d5rMR2Gzkt/xozFMe3xu7zzfPJ2bPsbA6/x619UnuTG3+nAcuR8RiNckOnkwepQPQXRf5FefT3NyqyOrFGcVOV6sRz2WIffDpYOfDDBF7eHRyvyZbbUVQsfXvDF7eGdNa+Ki3nbGaL58PZw/PjfB7UpLwAx6cxWlzW8zLq27Ihql9VuxYhOuX8jrDhkuG7BjMOv/n+DHV/QKguiDh+U+ez2UF5WBTu/PhTz2e2h2Jy7D2YwET8Mx48MfVCbIsafM1ZW5/Ub4eOoS34LJh5472eHg5EjuaSZmB13lFbwxe3hfdMSQXq4oECsi5338e1hnTV2UF0F7X3xc8KLm9Sq886+EbbspQLen0NvBvGzw6xvirbMQwD60f9rJu0bnqwPmKQf9uR805L//4HJHoq8vsZEc0rs/Sc5/trPzgR/PUP+w2IXs8rhgxpa+RiGQpnyaYfp9KPbw3hd1e2X9azrx3kf3x7W/weEQDIe34gQxPI2txCC+Gs/O0JA2HbmQz55Dwg9xr8d4/8cTa9m0r+R+ZXk+/tP8MB7Pzsz/I17xB/OMdQ+olC8j98D1tfkviF4/2/wz4fgvcqbvL7kHM7zYvk2hNn78vZw38wpJF9mRdmH2vnqPWC+h6K/ES/8OYCXfPX/Gu1iF9q+Ef1i1ubeX8MMvvmzo2O+idn+piX5GdGzzzju09tD6ovF+0rD13Ghfo44WNd5vxH+laXh9+fegfd+dnj3R3x3O1gfYiV+Vnm5t+rWbWJ710/s33bVTVe8vvCX4pgOWFjj8Te6+tZdApMmH6VErEviWlr+en3dtPnCiUFZwNmzDb7IlsU5pZveVG9zWvqkFbr7tBpaFlkj66Dvtbj38O7O3t18trjbNLMysrQHeho3MLKu9fj3yq+7M2Fm/VV+7olXOKWP73ZftK9576Dzzz6aFBcFxs8y/nlO0wO352XWtnm9RMOcMf0ofbEuy2yChdnzrGx6gtLtIZBO6Wp5mdXTeUZc/UX27nm+vGjnROD7933Ybb2+EXSwVvbNgrZLZ4Y47XsP3F8yC0m8EZAvYhsZJb7m9CNWiYI2i1kC9eZZ6EMwC1lfH4Jdw3oPbuhD8bNe7wHo1mwVWQX6/zJPBcGzdDWjP9sCJv49Yf0s8qcXt34gkkHMelvtdWvu2LwC8/9lRtE4aMO0BpP6IUT8/x/xfhYl4+Z5uRHorSemv6rx/+VJ+ZqW4oc6u2al5IPw05USVZz5tFhkJRx5+q0hnD/7aPeAqEuxEn29997QvSDs69v+HyYX95cl4lwMBP/fz8WStP5Ao/iNcfCtJyGydPD/5Vn4Rt0ob0a/3izEYQZC+vWx+6ZYpQ/659jJ64PprUV8s+PtpJu+YeAfrlE3YIw/Pwz4rTVFdAng/8u64r1n5lZQfxbl0uV8v1m4Pxts/zW8kVtzYiSd//9lPvx/GcfcCuf3ZZlbAf0aPPOzqsyHGPK4aappwebIuB2cDP/9B1Kdp8tZ+qpCH7aB4oUE/dh9+MW6bItVWUypU4oGeotmXy6f5mXe5imsKgKGk6yZZrM+TQjx2RAOmrj3MTAfhf1/qweWJCmvweVZSYsjTVvT8khv6YWinOW0WGVld8ydhreUUIzGgux+8zRf5UvIXTi22/Tkp737PVrAHbreRIHHdz3m2MwzBoHfP5bJdNMl3/qzpZ/8UJjlvRj2G2KYCD203TfMLe/FmTYr/nPLLAM5uf6M2YaxmXNf/v+WizZngPWVn0uG8tNePyc8hSzi7x9Jwrh54y/9OZMPfig8wzlOv2/54GeFV/pE0GbfMH/087bcrN+PSTf+nPCFYczfH+g2g8wRVTA/ZMXyw2SSH6YiuTWj/JCViPjD9E5Lb+S1QaKa5c+Kumkpu5VNsqbvzOCt13kbeMsfpc677vihr6fzfJFR3mlS0eyKey7fNb257AJ3ZqUH3n0V68B8e3MX6oD14OvnMeD81c2Q+/Z5cBCuyabBaKvb9L2hz819vUcfIp49+PJxDPazqprdDFbMUg+sfBwDi29uBiu58T5c/TwGmL+6GbLJpfVh229i0PXLm+FLhqQPXT+Pweav+pA9RdAVYBfupl6rQJQHIuJAh3cFlrrxP+xptX4k671nPurakHAYtxhiJzqLjHBT/BagGagLxlI/2TC09yLKhwzPifaGEQ6Zvo1hRwRx9+XP4dCd2xsZ8oBPHCDoaxtGTj7YMCRf7fEb8sEHD6XjqUXGs8mXC1CMztut5utDB2eybNarsN89viuKSj+gPynzml3kX5C/UTb8Kfky6yWWpuQvSqUWFw7EY4K5zNm/dEBNm7PleWUcqg5GpkkntfhF3ma0FJYd121xnk1b+nqaN02xvPgo/cmsXEP/Lyb57Gz55bpdrVsacr6YlAH54JRt6v/x3R7Oj7/k3HDzTQyB0Cywmvfl8sm6KGcW72eRdPwACHh7mv3GXLbIgl9cW0gvquUtASn5nhon9U2+WJUErPly+Tq7zAPcApA30zCk2OOnRXZRZwufgvKJcegy6tnrgjrw33D90Z/ErrPFu6P/JwAA//9rfdjYkYAAAA=="; }
        }
    }
}
