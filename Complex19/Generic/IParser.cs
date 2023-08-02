// SPDX-FileCopyrightText: 2023 Eitsop
// SPDX-License-Identifier: MIT

namespace Complex19.Generic
{
    public interface IParser<TParsedType>
    {
        TParsedType Parse();
    }
}
